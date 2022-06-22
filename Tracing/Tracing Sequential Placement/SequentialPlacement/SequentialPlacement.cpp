#include <fstream>
#include <string>
#include <iostream>
#include <vector>
#include <cmath>
using namespace std;

vector<string> ReadLines(string fileName)
{
    const string fileNotFoundMessage = "Файл " + fileName + " не найден.";
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

int** ReadMatrix(string fileName, int& matrixSize)
{
    const string invalidMatrixMessage = "Некорректная матрица.";
    const char* separator = "\t";

    vector<string> lines = ReadLines(fileName);
    matrixSize = lines.size();
    int** matrix = new int* [matrixSize];
    for (int i = 0; i < matrixSize; i++)
        matrix[i] = new int[matrixSize];

    for (int i = 0; i < matrixSize; i++)
    {
        char* line = new char[matrixSize + 1];
        strcpy(line, lines[i].c_str());
        char* element = strtok(line, separator);
        vector<string> elements;
        while (element != NULL)
        {
            elements.push_back(element);
            element = strtok(NULL, separator);
        }

        if (elements.size() != matrixSize)
        {
            cout << invalidMatrixMessage << endl;

            matrixSize = -1;
            return nullptr;
        }

        for (int j = 0; j < matrixSize; j++)
            matrix[i][j] = stoi(elements[j]);

        elements.clear();
    }

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = i; j < matrixSize; j++)
        {
            if (matrix[i][j] != matrix[j][i])
            {
                cout << invalidMatrixMessage << endl;

                matrixSize = -1;
                return nullptr;
            }
        }
    }

    return matrix;
}

string** ReadStartLocation(string fileName, int& rows, int& cols, int matrixSize)
{
    const char* separator = "\t";

    vector<string> lines = ReadLines(fileName);
    rows = lines.size();
    string** location = new string * [rows];

    int elementsCount = 0;
    for (int i = 0; i < rows; i++)
    {
        char* line = new char[lines.size() + 1];
        strcpy(line, lines[i].c_str());
        char* element = strtok(line, separator);
        vector<string> elements;
        while (element != NULL)
        {
            elements.push_back(element);
            element = strtok(NULL, separator);
        }

        cols = elements.size();
        location[i] = new string[cols];
        for (int j = 0; j < cols; j++)
            location[i][j] = elements[j];

        elementsCount += cols;
        elements.clear();
    }

    if (elementsCount != matrixSize)
    {
        rows = -1;
        cols = -1;
        return nullptr;
    }
    else
    {
        return location;
    }
}

struct Coord
{
    int i;
    int j;
};

struct Element
{
    string name;
    Coord coord;
};

bool CheckFixedElements(vector<Element>& fixedElements, string** location, int rows, int cols)
{
    for (int i = 0; i < fixedElements.size(); i++)
    {
        bool isFound = false;
        for (int j = 0; j < rows; j++)
        {
            for (int k = 0; k < cols; k++)
            {
                if (location[j][k] == fixedElements[i].name)
                {
                    fixedElements[i].coord.i = j;
                    fixedElements[i].coord.j = k;

                    isFound = true;
                }
            }
        }

        if (!isFound)
            return false;
    }

    return true;
}

void ShowMatrix(int** matrix, int matrixSize)
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            cout << matrix[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

void ShowLocation(string** location, int rows, int cols)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            cout << location[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

bool CheckNewPosition(vector<Element>& fixedElements, vector<Coord> availablePositions, int coordI, int coordJ)
{
    for (int i = 0; i < fixedElements.size(); i++)
        if ((fixedElements[i].coord.i == coordI) && (fixedElements[i].coord.j == coordJ))
            return false;

    for (int i = 0; i < availablePositions.size(); i++)
        if ((availablePositions[i].i == coordI) && (availablePositions[i].j == coordJ))
            return false;

    return true;
}

vector<Coord> GetFreeNeighboringCoord(vector<Element>& fixedElements, int rows, int cols)
{
    vector<Coord> freePositions;
    for (int i = 0; i < fixedElements.size(); i++)
    {
        if (fixedElements[i].coord.i - 1 >= 0)
        {
            if (CheckNewPosition(fixedElements, freePositions, fixedElements[i].coord.i - 1, fixedElements[i].coord.j))
            {
                Coord newPosition = { fixedElements[i].coord.i - 1, fixedElements[i].coord.j };
                freePositions.push_back(newPosition);
            }
        }
        if (fixedElements[i].coord.j - 1 >= 0)
        {
            if (CheckNewPosition(fixedElements, freePositions, fixedElements[i].coord.i, fixedElements[i].coord.j - 1))
            {
                Coord newPosition = { fixedElements[i].coord.i, fixedElements[i].coord.j - 1 };
                freePositions.push_back(newPosition);
            }
        }
        if (fixedElements[i].coord.j + 1 < cols)
        {
            if (CheckNewPosition(fixedElements, freePositions, fixedElements[i].coord.i, fixedElements[i].coord.j + 1))
            {
                Coord newPosition = { fixedElements[i].coord.i, fixedElements[i].coord.j + 1 };
                freePositions.push_back(newPosition);
            }
        }
        if (fixedElements[i].coord.i + 1 < rows)
        {
            if (CheckNewPosition(fixedElements, freePositions, fixedElements[i].coord.i + 1, fixedElements[i].coord.j))
            {
                Coord newPosition = { fixedElements[i].coord.i + 1, fixedElements[i].coord.j };
                freePositions.push_back(newPosition);
            }
        }
    }

    return freePositions;
}

string** GetCurrentLocation(vector<Element>& fixedElements, int rows, int cols, vector<Coord> availablePositions)
{
    string emptyCell = ".";
    string availablePosition = "+";

    string** location = new string* [rows];
    for (int i = 0; i < rows; i++)
    {
        location[i] = new string[cols];
        for (int j = 0; j < cols; j++)
        {
            location[i][j] = emptyCell;
        }
    }

    for (int i = 0; i < fixedElements.size(); i++)
    {
        location[fixedElements[i].coord.i][fixedElements[i].coord.j] = fixedElements[i].name;
    }

    for (int i = 0; i < availablePositions.size(); i++)
    {
        location[availablePositions[i].i][availablePositions[i].j] = availablePosition;
    }

    return location;
}

vector<Element> GetUnplacedElements(vector<Element>& fixedElements, string** location, int rows, int cols)
{
    vector<Element> unplacedElements;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            bool isFixed = false;
            for (int k = 0; k < fixedElements.size(); k++)
            {
                if (location[i][j] == fixedElements[k].name)
                {
                    isFixed = true;
                }
            }

            if (!isFixed)
            {
                Element unplacedElement;
                unplacedElement.name = location[i][j];
                unplacedElement.coord = { i, j };
                unplacedElements.push_back(unplacedElement);
            }
        }
    }

    return unplacedElements;
}

int* GetElementsEstimates(vector<Element> unplacedElements, vector<Element> fixedElements, 
    int rows, int cols, int** matrix, int matrixSize)
{
    int* estimates = new int[unplacedElements.size()];
    for (int i = 0; i < unplacedElements.size(); i++)
    {
        estimates[i] = 0;
        int position = unplacedElements[i].coord.i * cols + unplacedElements[i].coord.j;
        for (int j = 0; j < matrixSize; j++)
        {
            if (matrix[position][j] != 0)
            {
                int elementI = j / cols;
                int elementJ = j % cols;

                bool isFixed = true;
                for (int k = 0; k < unplacedElements.size(); k++)
                {
                    if ((unplacedElements[k].coord.i == elementI) && (unplacedElements[k].coord.j == elementJ))
                    {
                        isFixed = false;
                    }
                }

                if (isFixed)
                {
                    estimates[i] += matrix[position][j];
                }
                else
                {
                    estimates[i] -= matrix[position][j];
                }
            }
        }
    }

    return estimates;
}

int GetPositionsDistance(Coord source, Coord destination)
{
    return abs(source.i - destination.i) + abs(source.j - destination.j);
}

Coord GetElementCoord(string** location, int rows, int cols, Element element)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (location[i][j] == element.name)
            {
                Coord coord = { i, j };
                return coord;
            }
        }
    }
}

int* GetPositionsEstimates(Element placedElement, vector<Coord> availablePositions, vector<Element> fixedElements, 
    string** location, int rows, int cols, int** matrix, int matrixSize)
{
    int* estimates = new int[availablePositions.size()];

    int matrixI = placedElement.coord.i * cols + placedElement.coord.j;
    for (int i = 0; i < availablePositions.size(); i++)
    {
        estimates[i] = 0;
        for (int j = 0; j < fixedElements.size(); j++)
        {
            Coord elementCoord = GetElementCoord(location, rows, cols, fixedElements[j]);

            int matrixJ = elementCoord.i * cols + elementCoord.j;
            int connectionLength = matrix[matrixI][matrixJ];

            int distance = GetPositionsDistance(availablePositions[i], fixedElements[j].coord);
            estimates[i] += connectionLength * distance;
        }
    }

    return estimates;
}

int GetMaxEstimateIndex(int* estimates, int count)
{
    int maxIndex = 0;
    for (int i = 1; i < count; i++)
        if (estimates[i] > estimates[maxIndex])
            maxIndex = i;

    return maxIndex;
}

int GetMinEstimateIndex(int* estimates, int count)
{
    int minIndex = 0;
    for (int i = 1; i < count; i++)
        if (estimates[i] < estimates[minIndex])
            minIndex = i;

    return minIndex;
}

void PlacementStep(vector<Element>& fixedElements, string** location, int rows, int cols, int** matrix, int matrixSize)
{
    vector<Coord> availablePositions = GetFreeNeighboringCoord(fixedElements, rows, cols);
    string** currentLocation = GetCurrentLocation(fixedElements, rows, cols, availablePositions);

    cout << "Текущее размещение:" << endl;
    ShowLocation(currentLocation, rows, cols);

    cout << "Зафиксированные элементы: ";
    for (int i = 0; i < fixedElements.size(); i++)
    {
        int position = fixedElements[i].coord.i * cols + fixedElements[i].coord.j + 1;
        cout << fixedElements[i].name << "->" << position << " ";
    }
    cout << endl;

    cout << "Свободные позиции: ";
    for (int i = 0; i < availablePositions.size(); i++)
    {
        int position = availablePositions[i].i * cols + availablePositions[i].j + 1;
        cout << position << " ";
    }
    cout << "\n" << endl;

    vector<Element> unplacedElements = GetUnplacedElements(fixedElements, location, rows, cols);
    int* elementsEstimates = GetElementsEstimates(unplacedElements, fixedElements, rows, cols, matrix, matrixSize);

    cout << "Оценки по связности неразмещённых элементов:" << endl;
    for (int i = 0; i < unplacedElements.size(); i++)
        cout << "J(" << unplacedElements[i].name << ") = " << elementsEstimates[i] << endl;
    cout << endl;

    int placedIndex = GetMaxEstimateIndex(elementsEstimates, unplacedElements.size());
    cout << "Выбираем для размещения элемент " << unplacedElements[placedIndex].name << endl;
    cout << endl;

    int* positionsEstimates = GetPositionsEstimates(unplacedElements[placedIndex], availablePositions, 
        fixedElements, location, rows, cols, matrix, matrixSize);

    cout << "Оценки доступных позиций:" << endl;
    for (int i = 0; i < availablePositions.size(); i++)
    {
        int position = availablePositions[i].i * cols + availablePositions[i].j + 1;
        cout << "F" << position << " = " << positionsEstimates[i] << endl;
    }
    cout << endl;

    int positionIndex = GetMinEstimateIndex(positionsEstimates, availablePositions.size());
    int position = availablePositions[positionIndex].i * cols + availablePositions[positionIndex].j + 1;
    cout << "Размещаем элемент " << unplacedElements[placedIndex].name << " в позицию " << position << endl;
    cout << endl;

    Element placedElement = { unplacedElements[placedIndex].name, availablePositions[positionIndex] };
    fixedElements.push_back(placedElement);
}

void ShowPlacement(vector<Element> fixedElements, string** location, int rows, int cols, int** matrix, int matrixSize)
{
    int step = 1;
    while (fixedElements.size() != rows * cols)
    {
        cout << "\nШаг " << step << ":" << endl;
        PlacementStep(fixedElements, location, rows, cols, matrix, matrixSize);

        step++;
    }
    cout << endl;

    vector<Coord> availablePositions;
    string** resultLocation = GetCurrentLocation(fixedElements, rows, cols, availablePositions);

    cout << "Полученное размещение:" << endl;
    ShowLocation(resultLocation, rows, cols);
}

int main(int argc, char* argv[])
{
    setlocale(LC_ALL, "RUSSIAN");
    const string matrixFileName = "Matrix.txt";
    const string startLocationFileName = "InitialLocation.txt";

    const int defaultFixedI = 0;
    const int defaultFixedJ = 0;

    vector<Element> fixedElements;
    if (argc > 1)
    {
        for (int i = 1; i < argc; i++)
        {
            Element fixed;
            fixed.name = string(argv[i]);
            fixedElements.push_back(fixed);
        }
    }

    int matrixSize;
    int** matrix = ReadMatrix(matrixFileName, matrixSize);

    if (matrixSize > 0)
    {
        cout << "Считанная матрица связей:" << endl;
        ShowMatrix(matrix, matrixSize);

        int rows;
        int cols;
        string** location = ReadStartLocation(startLocationFileName, rows, cols, matrixSize);
        if ((rows > 0) && (matrixSize == rows * cols))
        {
            cout << "Считанное начальное распределение:" << endl;
            ShowLocation(location, rows, cols);

            bool isFixedCorrect;
            if (argc <= 1)
            {
                Coord coord = { defaultFixedI, defaultFixedJ };
                Element fixed = { location[defaultFixedI][defaultFixedJ], coord };
                fixedElements.push_back(fixed);
                isFixedCorrect = true;
            }
            else
            {
                isFixedCorrect = CheckFixedElements(fixedElements, location, rows, cols);
            }

            if (isFixedCorrect)
            {
                cout << "Зафиксированные элементы: ";
                for (int i = 0; i < fixedElements.size(); i++)
                {
                    int position = fixedElements[i].coord.i * cols + fixedElements[i].coord.j + 1;
                    cout << fixedElements[i].name << "->" << position << " ";
                }
                cout << "\n\n" << endl;

                cout << "Последовательный алгоритм размещения по связности:\n" << endl;
                ShowPlacement(fixedElements, location, rows, cols, matrix, matrixSize);

                return 0;
            }
            else
            {
                cout << "Некорректные зафиксированные элементы!" << endl;
            }
        }
        else
        {
            cout << "Некорректное начальное распределение элементов." << endl;
        }
    }

    return -1;
}