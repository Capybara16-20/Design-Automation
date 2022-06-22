#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

const char startElement = 'A';
const char endElement = 'B';
const char emptyCell = '.';
const char blockCell = '#';
const char downArrow = 'v';
const char leftArrow = '<';
const char upArrow = '^';
const char rightArrow = '>';

vector<string> ReadLines(string fileName)
{
    string fileNotFoundMessage = "Файл " + fileName + " не найден.";
    string path = "../" + fileName;

    vector<string> lines;
    ifstream file(path);
    string line;
    if (file.is_open())
    {
        while (getline(file, line))
        {
            lines.push_back(line);
        }
        file.close();
    }
    else
    {
        cout << fileNotFoundMessage << endl;
    }

    return lines;
}

struct PathElement
{
    int i;
    int j;
    int length;
    int source;
    char symbol;
};

char** ReadField(string fileName, int& rows, int& cols, PathElement& start, PathElement& end)
{
    const string invalidFieldMessage = "Некорректное поле.";

    vector<string> lines = ReadLines(fileName);
    if (lines.size() == 0)
    {
        rows = -1;
        return nullptr;
    }

    rows = lines.size();
    cols = lines[0].size();
    char** field = new char* [rows];
    int startCellsCount = 0;
    int endCellsCount = 0;
    for (int i = 0; i < rows; i++)
    {
        int currentCols = lines[i].size();
        if (currentCols != cols)
        {
            cout << invalidFieldMessage << endl;

            rows = -1;
            return nullptr;
        }

        field[i] = new char[cols];
        for (int j = 0; j < cols; j++)
        {
            switch (lines[i][j])
            {
            case startElement:
                field[i][j] = startElement;
                start.i = i;
                start.j = j;
                start.length = 0;
                start.source = -1;
                startCellsCount++;
                break;
            case endElement:
                field[i][j] = endElement;
                end.i = i;
                end.j = j;
                end.length = 0;
                end.source = -1;
                endCellsCount++;
                break;
            case blockCell:
                field[i][j] = blockCell;
                break;
            case emptyCell:
                field[i][j] = emptyCell;
                break;
            default:
                cout << invalidFieldMessage << endl;

                rows = -1;
                return nullptr;
            }
        }
    }

    if ((startCellsCount != 1) || (endCellsCount != 1))
    {
        cout << invalidFieldMessage << endl;

        rows = -1;
        return nullptr;
    }

    return field;
}

void ShowField(char** field, int rows, int cols, vector<PathElement>& path, int offsetI = 0, int offsetJ = 0)
{
    string** outputField = new string * [rows];
    for (int i = 0; i < rows; i++)
    {
        outputField[i] = new string[cols];
        for (int j = 0; j < cols; j++)
        {
            outputField[i][j] = field[i][j];
        }
    }

    for (int i = 1; i < path.size(); i++)
    {
        PathElement element = path[i];
        string cell = "[" + to_string(i) + "]" + outputField[element.i - offsetI][element.j - offsetJ] + to_string(element.length);
        outputField[element.i - offsetI][element.j - offsetJ] = cell;
    }

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            cout << outputField[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

char** GetFieldPart(char** field, int rows, int cols, PathElement start, PathElement end, int& newRows, int& newCols)
{
    int startI, startJ, endI, endJ;
    if (start.i <= end.i)
    {
        startI = start.i;
        endI = end.i;
    }
    else
    {
        startI = end.i;
        endI = start.i;
    }
    if (start.j <= end.j)
    {
        startJ = start.j;
        endJ = end.j;
    }
    else
    {
        startJ = end.j;
        endJ = start.j;
    }

    newRows = endI - startI + 1;
    newCols = endJ - startJ + 1;
    char** fieldPart = new char* [newRows];
    for (int i = 0; i < newRows; i++)
    {
        fieldPart[i] = new char[newCols];
        for (int j = 0; j < newCols; j++)
        {
            fieldPart[i][j] = field[i + startI][j + startJ];
        }
    }

    return fieldPart;
}

char** GetIncreasedField(char** field, int rows, int cols, char** currentField,
    int& offsetI, int& offsetJ, int& currentRows, int& currentCols)
{
    int newOffsetI = offsetI;
    int newOffsetJ = offsetJ;
    int newRows = currentRows;
    int newCols = currentCols;
    if (offsetI > 0)
    {
        newOffsetI--;
        newRows++;
    }
    if (offsetI + currentRows < rows)
    {
        newRows++;
    }
    if (offsetJ > 0)
    {
        newOffsetJ--;
        newCols++;
    }
    if (offsetJ + currentCols < cols)
    {
        newCols++;
    }

    char** newField = new char* [newRows];
    for (int i = 0; i < newRows; i++)
    {
        newField[i] = new char[newCols];
        for (int j = 0; j < newCols; j++)
        {
            newField[i][j] = field[i + newOffsetI][j + newOffsetJ];
        }
    }

    for (int i = 0; i < currentRows; i++)
    {
        for (int j = 0; j < currentCols; j++)
        {
            newField[i + offsetI - newOffsetI][j + offsetJ - newOffsetJ] = currentField[i][j];
        }
    }

    offsetI = newOffsetI;
    offsetJ = newOffsetJ;
    currentRows = newRows;
    currentCols = newCols;
    return newField;
}

int CheckAvailableDirections(char** field, int rows, int cols, int i, int j)
{
    if (i - 1 >= 0)
    {
        if ((field[i - 1][j] == emptyCell) || (field[i - 1][j] == endElement))
        {
            return downArrow;
        }
    }
    if (j + 1 < cols)
    {
        if ((field[i][j + 1] == emptyCell) || (field[i][j + 1] == endElement))
        {
            return leftArrow;
        }
    }
    if (i + 1 < rows)
    {
        if ((field[i + 1][j] == emptyCell) || (field[i + 1][j] == endElement))
        {
            return upArrow;
        }
    }
    if (j - 1 >= 0)
    {
        if ((field[i][j - 1] == emptyCell) || (field[i][j - 1] == endElement))
        {
            return rightArrow;
        }
    }

    return blockCell;
}

bool AddElement(char** currentField, int& currentRows, int& currentCols, 
    int& offsetI, int& offsetJ, vector<PathElement>& path, int& consideredIndex)
{
    bool isAdded = false;
    PathElement newElement;
    while (!isAdded)
    {
        PathElement currentElement = path[consideredIndex];
        char direction = CheckAvailableDirections(currentField, currentRows, currentCols, 
            currentElement.i - offsetI, currentElement.j - offsetJ);

        if (direction == blockCell)
        {
            consideredIndex++;

            if (consideredIndex == path.size())
            {
                return false;
            }
        }
        else
        {
            int i = path[consideredIndex].i;
            int j = path[consideredIndex].j;
            switch (direction)
            {
            case downArrow:
                newElement.i = i - 1;
                newElement.j = j;
                newElement.symbol = downArrow;
                currentField[i - 1 - offsetI][j - offsetJ] = downArrow;
                break;
            case leftArrow:
                newElement.i = i;
                newElement.j = j + 1;
                newElement.symbol = leftArrow;
                currentField[i - offsetI][j + 1 - offsetJ] = leftArrow;
                break;
            case upArrow:
                newElement.i = i + 1;
                newElement.j = j;
                newElement.symbol = upArrow;
                currentField[i + 1 - offsetI][j - offsetJ] = upArrow;
                break;
            case rightArrow:
                newElement.i = i;
                newElement.j = j - 1;
                newElement.symbol = rightArrow;
                currentField[i - offsetI][j - 1 - offsetJ] = rightArrow;
                break;
            }
            newElement.length = path[consideredIndex].length + 1;
            newElement.source = consideredIndex;
            path.push_back(newElement);

            isAdded = true;
            return true;
        }
    }
}

bool CheckPathFound(vector<PathElement> path, PathElement end)
{
    PathElement lastAdded = path.back();
    return (lastAdded.i == end.i) && (lastAdded.j == end.j);
}

vector<PathElement> GetResultPath(vector<PathElement> path)
{
    vector<PathElement> resultPath;
    PathElement currentElement = path.back();
    while (currentElement.source >= 0)
    {
        resultPath.push_back(currentElement);
        currentElement = path[currentElement.source];
    }
    resultPath.push_back(currentElement);

    return resultPath;
}

vector<PathElement> FindPath(char** field, int rows, int cols, PathElement start, PathElement end, bool& isPathFound)
{
    vector<PathElement> path;
    path.push_back(start);

    int offsetI = (start.i <= end.i) ? start.i : end.i;
    int offsetJ = (start.j <= end.j) ? start.j : end.j;
    int currentRows, currentCols;
    char** currentField = GetFieldPart(field, rows, cols, start, end, currentRows, currentCols);
    cout << "Ограничиваем поле:" << endl;
    ShowField(currentField, currentRows, currentCols, path, offsetI, offsetJ);

    int step = 1;
    int consideredIndex = 0;
    isPathFound = false;
    while (!isPathFound)
    {
        bool isAdded = AddElement(currentField, currentRows, currentCols, offsetI, offsetJ, path, consideredIndex);
        if (isAdded)
        {
            if (CheckPathFound(path, end))
            {
                cout << "Путь найден!" << endl;
                isPathFound = true;
            }
            
            cout << "Шаг " << step << ":" << endl;
            ShowField(currentField, currentRows, currentCols, path, offsetI, offsetJ);

            step++;
        }
        else
        {
            if ((currentRows == rows) && (currentCols == cols))
            {
                return path;
            }

            currentField = GetIncreasedField(field, rows, cols, 
                currentField, offsetI, offsetJ, currentRows, currentCols);
            consideredIndex = 0;

            cout << "Увеличиваем поле:" << endl;
            ShowField(currentField, currentRows, currentCols, path, offsetI, offsetJ);
        }
    }

    path = GetResultPath(path);
    return path;
}

void ShowPath(char** field, int rows, int cols, vector<PathElement> path)
{
    char** outputField = new char* [rows];
    for (int i = 0; i < rows; i++)
    {
        outputField[i] = new char[cols];
        for (int j = 0; j < cols; j++)
        {
            outputField[i][j] = field[i][j];
        }
    }

    for (int i = 1; i < path.size() - 1; i++)
    {
        char symbol = emptyCell;
        switch (path[i].symbol)
        {
        case downArrow:
            symbol = upArrow;
            break;
        case leftArrow:
            symbol = rightArrow;
            break;
        case upArrow:
            symbol = downArrow;
            break;
        case rightArrow:
            symbol = leftArrow;
            break;
        }

        outputField[path[i].i][path[i].j] = symbol;
    }

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            cout << outputField[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

int main()
{
    setlocale(LC_ALL, "RUSSIAN");
    string fileName = "Field.txt";

    int rows;
    int cols;
    PathElement start;
    PathElement end;
    char** field = ReadField(fileName, rows, cols, start, end);
    vector<PathElement> path;
    if (rows > 0)
    {
        cout << "Считанное поле:" << endl;
        ShowField(field, rows, cols, path);

        bool isPathFound;
        vector<PathElement> path = FindPath(field, rows, cols, start, end, isPathFound);
        if (isPathFound)
        {
            cout << "Найденный путь:" << endl;
            ShowPath(field, rows, cols, path);
            cout << "Длина пути: " << path.size() - 1 << endl;
        }
		else
		{
			cout << "Путь отсутствует!" << endl;
		}
    }

    system("pause");
}
