#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

const char letCell = '#';
const int letCellIndex = -1;
const char emptyCell = '-';
const int emptyCellIndex = 0;
const char startCell = 'A';
const int startCellIndex = 1;
const char endCell = 'B';
const int endCellIndex = 2;

const char downArrow = 'v';
const int downArrowIndex = -2;
const char leftArrow = '<';
const int leftArrowIndex = -3;
const char upArrow = '^';
const int upArrowIndex = -4;
const char rightArrow = '>';
const int rightArrowIndex = -5;

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
};

int** ReadField(string fileName, int& rows, int& cols, PathElement& start, PathElement& end)
{
    const string invalidFieldMessage = "Некорректное поле.";
    const char* separator = "";

    vector<string> lines = ReadLines(fileName);
    if (lines.size() == 0)
    {
        cout << invalidFieldMessage << endl;

        rows = -1;
        return nullptr;
    }

    rows = lines.size();
    cols = lines[0].size();
    int** field = new int* [rows];
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

        field[i] = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            switch (lines[i][j])
            {
            case letCell:
                field[i][j] = letCellIndex;
                break;
            case emptyCell:
                field[i][j] = emptyCellIndex;
                break;
            case startCell:
                field[i][j] = startCellIndex;
                start.i = i;
                start.j = j;
                start.length = 0;
                start.source = -1;
                startCellsCount++;
                break;
            case endCell:
                field[i][j] = endCellIndex;
                end.i = i;
                end.j = j;
                end.length = 0;
                end.source = -1;
                endCellsCount++;
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

void ShowField(int** field, int rows, int cols)
{
    cout << "\t";
    for (int i = 0; i < cols; i++)
        cout << i + 1 << "\t";
    cout << endl;

    for (int i = 0; i < rows; i++)
    {
        cout << i + 1 << "\t";
        for (int j = 0; j < cols; j++)
        {
            switch (field[i][j])
            {
            case letCellIndex:
                cout << letCell << "\t";
                break;
            case emptyCellIndex:
                cout << emptyCell << "\t";
                break;
            case startCellIndex:
                cout << startCell << "\t";
                break;
            case endCellIndex:
                cout << endCell << "\t";
                break;
            case downArrowIndex:
                cout << downArrow << "\t";
                break;
            case leftArrowIndex:
                cout << leftArrow << "\t";
                break;
            case upArrowIndex:
                cout << upArrow << "\t";
                break;
            case rightArrowIndex:
                cout << rightArrow << "\t";
                break;
            default:
                cout << field[i][j] << "\t";
                break;
            }
        }
        cout << endl;
    }
    cout << endl;
}

bool CheckPathIntersection(int i, int j, vector<PathElement> path, PathElement& commonElement)
{
    for (int k = 0; k < path.size(); k++)
    {
        if ((path[k].i == i) && (path[k].j == j))
        {
            commonElement = path[k];
            return true;
        }
    }

    return false;
}

int CheckAvailableDirections(int** field, int rows, int cols, PathElement element, 
    vector<PathElement> otherPath, PathElement& commonElement, bool& isIntersectionFound)
{
    isIntersectionFound = false;
    int i = element.i;
    int j = element.j;
    if (i - 1 >= 0)
    {
        if (field[i - 1][j] == 0)
        {
            return downArrowIndex;
        }
        else if (CheckPathIntersection(i - 1, j, otherPath, commonElement))
        {
            isIntersectionFound = true;
            return downArrowIndex;
        }
    }
    if (j + 1 < cols)
    {
        if (field[i][j + 1] == 0)
        {
            return leftArrowIndex;
        }
        else if (CheckPathIntersection(i, j + 1, otherPath, commonElement))
        {
            isIntersectionFound = true;
            return leftArrowIndex;
        }
    }
    if (i + 1 < rows)
    {
        if (field[i + 1][j] == 0)
        {
            return upArrowIndex;
        }
        else if (CheckPathIntersection(i + 1, j, otherPath, commonElement))
        {
            isIntersectionFound = true;
            return upArrowIndex;
        }
    }
    if (j - 1 >= 0)
    {
        if (field[i][j - 1] == 0)
        {
            return rightArrowIndex;
        }
        else if (CheckPathIntersection(i, j - 1, otherPath, commonElement))
        {
            isIntersectionFound = true;
            return rightArrowIndex;
        }
    }

    return letCellIndex;
}

int AddNextElement(int** field, int rows, int cols, vector<PathElement>& path, 
    int& consideredIndex, vector<PathElement>& otherPath, PathElement& commonElement)
{
    bool isAdded = false;
    PathElement newElement;
    while (!isAdded)
    {
        bool isIntersectionFound = false;
        int directionIndex = CheckAvailableDirections(field, rows, cols, path[consideredIndex], 
            otherPath, commonElement, isIntersectionFound);
        
        if (directionIndex == letCellIndex)
        {
            consideredIndex++;

            if (consideredIndex == path.size())
            {
                return -1;
            }
        }
        else
        {
            int i = path[consideredIndex].i;
            int j = path[consideredIndex].j;
            switch (directionIndex)
            {
            case downArrowIndex:
                newElement.i = i - 1;
                newElement.j = j;
                field[i - 1][j] = downArrowIndex;
                break;
            case leftArrowIndex:
                newElement.i = i;
                newElement.j = j + 1;
                field[i][j + 1] = leftArrowIndex;
                break;
            case upArrowIndex:
                newElement.i = i + 1;
                newElement.j = j;
                field[i + 1][j] = upArrowIndex;
                break;
            case rightArrowIndex:
                newElement.i = i;
                newElement.j = j - 1;
                field[i][j - 1] = rightArrowIndex;
                break;
            }
            newElement.length = path[consideredIndex].length + 1;
            newElement.source = consideredIndex;
            path.push_back(newElement);

            isAdded = true;

            if (isIntersectionFound)
            {
                return 1;
            }
        }
    }

    return 0;
}

int** GetFieldCopy(int** field, int rows, int cols)
{
    int** copy = new int* [rows];;
    for (int i = 0; i < rows; i++)
    {
        copy[i] = new int[cols];
        for (int j = 0; j < cols; j++)
        {
            copy[i][j] = field[i][j];
        }
    }

    return copy;
}

vector<PathElement> GetResultPath(vector<PathElement> startPath, vector<PathElement> endPath, 
    PathElement commonElement)
{
    vector<PathElement> path;

    bool isElementFound = false;
    int index = 0;
    while (!isElementFound)
    {
        if ((endPath[index].i == commonElement.i)
            && (endPath[index].j == commonElement.j))
            isElementFound = true;
        else
            index++;
    }

    int currentElementIndex = endPath[index].source;
    while (currentElementIndex >= 0)
    {
        PathElement currentElement = endPath[currentElementIndex];
        path.push_back(currentElement);

        currentElementIndex = currentElement.source;
    }

    isElementFound = false;
    index = 0;
    while (!isElementFound)
    {
        if ((startPath[index].i == commonElement.i) 
            && (startPath[index].j == commonElement.j))
            isElementFound = true;
        else
            index++;
    }

    currentElementIndex = index;
    while (currentElementIndex >= 0)
    {
        PathElement currentElement = startPath[currentElementIndex];
        path.insert(path.begin(), currentElement);

        currentElementIndex = currentElement.source;
    }

    return path;
}

void ShowFoundPath(int** field, int** workField, int rows, int cols, vector<PathElement> path)
{
    for (int i = 0; i < path.size(); i++)
        field[path[i].i][path[i].j] = workField[path[i].i][path[i].j];

    ShowField(field, rows, cols);
}

void ShowPathFinding(int** field, int rows, int cols, PathElement start, PathElement end)
{
    const string noWayMessage = "Путь отсутствует!";

    int** workField = GetFieldCopy(field, rows, cols);

    vector<PathElement> startPath;
    startPath.push_back(start);
    vector<PathElement> endPath;
    endPath.push_back(end);

    int iteration = 1;
    int startConsideredIndex = 0;
    int endConsideredIndex = 0;
    PathElement commonElement;
    int isPathsCrossed = false;
    while (isPathsCrossed != 1)
    {
        isPathsCrossed = AddNextElement(workField, rows, cols, startPath, startConsideredIndex, endPath, commonElement);
        if (isPathsCrossed == -1)
        {
            cout << noWayMessage << endl;
            return;
        }
        else if (isPathsCrossed == 1)
        {
            continue;
        }

        isPathsCrossed = AddNextElement(workField, rows, cols, endPath, endConsideredIndex, startPath, commonElement);
        if (isPathsCrossed == -1)
        {
            cout << noWayMessage << endl;
            return;
        }
        else if (isPathsCrossed == 1)
        {
            continue;
        }

        system("cls");
        cout << "Итерация " << iteration << endl;
        ShowField(workField, rows, cols);
        system("pause");
        iteration++;
    }

    vector<PathElement> path = GetResultPath(startPath, endPath, commonElement);

    system("cls");
    cout << "Найденный путь:" << endl;
    ShowFoundPath(field, workField, rows, cols, path);
    cout << "Длина пути: " << path.size() - 1;
}

int main()
{
    setlocale(LC_ALL, "RUSSIAN");
    string fileName = "Field.txt";

    int rows;
    int cols;
    PathElement start;
    PathElement end;
    int** field = ReadField(fileName, rows, cols, start, end);
    if (rows > 0)
    {
        cout << "Считанное поле:" << endl;
        ShowField(field, rows, cols);
        system("pause");

        ShowPathFinding(field, rows, cols, start, end);
    }
}
