#include <fstream>
#include <string>
#include <iostream>
#include <vector>
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
    const string invalidLocationMessage = "Некорректное стартовое расположение элементов.";
    const char* separator = "\t";

    vector<string> lines = ReadLines(fileName);
    rows = lines.size();
    string** location = new string* [rows];

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
        cout << invalidLocationMessage << endl;

        rows = -1;
        cols = -1;
        return nullptr;
    }
    else
    {
        return location;
    }
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

void ShowHalfMatrix(int** matrix, int matrixSize)
{
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            if (i <= j)
            {
                cout << matrix[i][j];
            }
            cout << "\t";
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

int GetDistance(int sourceIndex, int destinationIndex, string** location, int cols)
{
    int sourceI = sourceIndex / cols;
    int sourceJ = sourceIndex % cols;
    int destinationI = destinationIndex / cols;
    int destinationJ = destinationIndex % cols;

    int distance = fabs(sourceJ - destinationJ) + fabs(sourceI - destinationI);
    return distance;
}

int** GetDistanceMatrix(int matrixSize, string** location, int cols)
{
    int** distanceMatrix = new int* [matrixSize];
    for (int i = 0; i < matrixSize; i++)
        distanceMatrix[i] = new int[matrixSize];

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            if (i == j)
            {
                distanceMatrix[i][j] = 0;
                distanceMatrix[j][i] = 0;
            }
            else
            {
                int distance = GetDistance(i, j, location, cols);
                distanceMatrix[i][j] = distance;
                distanceMatrix[j][i] = distance;
            }
        }
    }

    return distanceMatrix;
}

int** TransposeMatrix(int** matrix, int matrixSize)
{
    int** transpanent = new int* [matrixSize];
    for (int i = 0; i < matrixSize; i++)
    {
        transpanent[i] = new int[matrixSize];
        for (int j = 0; j < matrixSize; j++)
        {
            transpanent[i][j] = matrix[j][i];
        }
    }

    return transpanent;
}

int** MultiplyMatrices(int** a, int** b, int matrixSize)
{
    int** multuply = new int* [matrixSize];
    for (int i = 0; i < matrixSize; i++)
    {
        multuply[i] = new int[matrixSize];
        for (int j = 0; j < matrixSize; j++)
        {
            multuply[i][j] = 0;
            for (int k = 0; k < matrixSize; k++)
            {
                multuply[i][j] += a[i][k] * b[k][j];
            }
        }
    }

    multuply = TransposeMatrix(multuply, matrixSize);
    return multuply;
}

double GetIncrement(int** multuply, int matrixSize)
{
    double l = 0;
    for (int i = 0; i < matrixSize; i++)
        l += multuply[i][i];

    return l / 2;
}

int** GetGammaMatrix(int** matrix, int matrixSize)
{
    int** gamma = new int* [matrixSize];
    for (int i = 0; i < matrixSize; i++)
    {
        gamma[i] = new int[matrixSize];
        for (int j = 0; j < matrixSize; j++)
        {
            gamma[i][j] = matrix[i][j] - matrix[i][i];
        }
    }

    return gamma;
}

int** GetQMatrix(int** matrix, int matrixSize)
{
    int** transpanent = TransposeMatrix(matrix, matrixSize);
    int** qMatrix = new int* [matrixSize];
    for (int i = 0; i < matrixSize; i++)
    {
        qMatrix[i] = new int[matrixSize];
        for (int j = 0; j < matrixSize; j++)
        {
            if (i < j)
            {
                qMatrix[i][j] = matrix[i][j] + transpanent[i][j];
            }
            else
            {
                qMatrix[i][j] = 0;
            }
        }
    }

    return qMatrix;
}

int** GetLMatrix(int** matrix, int** distanceMatrix, int** qMatrix, int matrixSize)
{
    int** lMatrix = new int* [matrixSize];
    for (int i = 0; i < matrixSize; i++)
    {
        lMatrix[i] = new int[matrixSize];
        for (int j = 0; j < matrixSize; j++)
        {
            lMatrix[i][j] = 2 * matrix[i][j] * distanceMatrix[i][j] + qMatrix[i][j];
        }
    }

    return lMatrix;
}

int GetReplacement(int** matrix, int** lMatrix, int matrixSize, int& source, int& destination)
{
    int minLength = INT_MAX;
    source = -1;
    destination = -1;
    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = i + 1; j < matrixSize; j++)
        {
            if (lMatrix[i][j] < 0)
            {
                if ((lMatrix[i][j] < minLength) && (matrix[i][j] == 0))
                {
                    minLength = lMatrix[i][j];
                    source = i;
                    destination = j;
                }
            }
        }
    }

    return minLength;
}

void ReplaceLocation(string** location, int rows, int cols, int sourceIndex, int destinationIndex)
{
    int sourceI = sourceIndex / cols;
    int sourceJ = sourceIndex % cols;
    int destinationI = destinationIndex / cols;
    int destinationJ = destinationIndex % cols;

    string temp = location[sourceI][sourceJ];
    location[sourceI][sourceJ] = location[destinationI][destinationJ];
    location[destinationI][destinationJ] = temp;
}

void ReplaceMatrix(int** matrix, int matrixSize, int sourceIndex, int destinationIndex)
{
    for (int i = 0; i < matrixSize; i++)
    {
        int temp = matrix[sourceIndex][i];
        matrix[sourceIndex][i] = matrix[destinationIndex][i];
        matrix[destinationIndex][i] = temp;

        temp = matrix[i][destinationIndex];
        matrix[i][destinationIndex] = matrix[i][sourceIndex];
        matrix[i][sourceIndex] = temp;
    }
}

void StartAlgorithm(int** matrix, int matrixSize, string** location, int rows, int cols, int** distanceMatrix)
{
    int iteration = 1;
    bool isContinue = true;
    while (isContinue)
    {
        cout << "\nИтерация " << iteration << ":" << endl;
        
        int** multuply = MultiplyMatrices(matrix, distanceMatrix, matrixSize);
        cout << "Произведение матриц (R x P):" << endl;
        ShowMatrix(multuply, matrixSize);

        int l = GetIncrement(multuply, matrixSize);
        cout << "Суммарная длина связей: L = " << l << "\n" << endl;

        int** gamma = GetGammaMatrix(multuply, matrixSize);
        cout << "Gamma:" << endl;
        ShowMatrix(gamma, matrixSize);

        int** qMatrix = GetQMatrix(gamma, matrixSize);
        cout << "Q:" << endl;
        ShowHalfMatrix(qMatrix, matrixSize);

        int** lMatrix = GetLMatrix(matrix, distanceMatrix, qMatrix, matrixSize);
        cout << "Матрица приращений (L):" << endl;
        ShowHalfMatrix(lMatrix, matrixSize);

        int source;
        int destination;
        int length = GetReplacement(matrix, lMatrix, matrixSize, source, destination);

        if (source >= 0)
        {
            cout << "Перестановка: " << source + 1 << " -> " << destination + 1 << " [" << length << "]\n" << endl;

            ReplaceLocation(location, rows, cols, source, destination);
            cout << "Новое распределение:" << endl;
            ShowLocation(location, rows, cols);

            ReplaceMatrix(matrix, matrixSize, source, destination);
            cout << "Новая матрица связей:" << endl;
            ShowMatrix(matrix, matrixSize);
        }
        else
        {
            cout << "Итоговое распределение:" << endl;
            ShowLocation(location, rows, cols);

            cout << "Полученная матрица связей:" << endl;
            ShowMatrix(matrix, matrixSize);

            isContinue = false;
        }

        iteration++;
    }
}

int main()
{
    setlocale(LC_ALL, "RUSSIAN");
    const string matrixFileName = "Matrix.txt";
    const string startLocationFileName = "InitialLocation.txt";

    int matrixSize;
    int** matrix = ReadMatrix(matrixFileName, matrixSize);

    if (matrixSize > 0)
    {
        cout << "Считанная матрица (R):" << endl;
        ShowMatrix(matrix, matrixSize);

        int rows;
        int cols;
        string** location = ReadStartLocation(startLocationFileName, rows, cols, matrixSize);
        if (rows > 0)
        {
            cout << "Начальное распределение:" << endl;
            ShowLocation(location, rows, cols);

            int** distanceMatrix = GetDistanceMatrix(matrixSize, location, cols);
            cout << "Матрица расстояний (P):" << endl;
            ShowMatrix(distanceMatrix, matrixSize);

            StartAlgorithm(matrix, matrixSize, location, rows, cols, distanceMatrix);

            for (int i = 0; i < matrixSize; i++)
            {
                delete[] matrix[i];
                delete[] distanceMatrix[i];
            }
            for (int i = 0; i < rows; i++)
                delete[] location[i];

            return 0;
        }
    }

    return -1;
}
