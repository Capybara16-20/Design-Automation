#include <fstream>
#include <string>
#include <iostream>
#include <vector>
#include <algorithm> 
using namespace std;


/// <summary>
/// Проверка корректности матрицы смежности
/// </summary>
/// <param name="matrix">Матрица</param>
/// <param name="n">Размерность матрицы</param>
/// <returns></returns>
bool CheckMatrix(double** matrix, int n)
{
    for (int i = 0; i < n; i++)
    {
        if (matrix[i][i] != 0)
        {
            return false;
        }

        for (int j = i + 1; j < n; j++)
        {
            if (matrix[i][j] != matrix[j][i])
            {
                return false;
            }
        }
    }

    return true;
}

/// <summary>
/// Ввод матрицы с консоли
/// </summary>
/// <param name="n">Размерность матрицы</param>
/// <returns></returns>
double** InputMatrix(int& n)
{
    const string invalidMatrixMessage = "Некорректная матрица.";
    const string invalidValueMessage = "Некорректное значение.";

    cout << "Введите размерность матрицы: ";
    cin >> n; //размерность
    
    if (n < 2) //не может быть меньше 2
    {
        cout << invalidValueMessage << endl;

        n = -1;
        return nullptr;
    }

    double** matrix = new double* [n]; //матрица
    for (int i = 0; i < n; i++)
        matrix[i] = new double[n];

    bool isCorrect;
    for (int i = 0; i < n; i++)
    {
        matrix[i][i] = 0; //главная диагональ равна 0
        for (int j = i + 1; j < n; j++) //проходим по элементам выше главной диагонали
        {
            isCorrect = false; //корректен ли ввод значения
            while (!isCorrect) //пока он не корректен
            {
                cout << "L[" << i + 1 << " -> " << j + 1 << "] = "; //запрашиваем ввод
                if ((cin >> matrix[i][j]).fail()) //если некорректный ввод
                {
                    cout << invalidValueMessage << endl; //выводим сообщение 
                }
                else //иначе
                {
                    matrix[j][i] = matrix[i][j]; //зеркально по главной диагонали в матрице записываем это значение
                    isCorrect = true; //ввод корректен
                }
                cin.clear(); //это для некорректного ввода надо флаги ошибки почистить и игнорить, иначе больше ввод работать не будет
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
            }
        }
    }
    cout << endl;

    if (!CheckMatrix(matrix, n)) //проверка корректности полученной матрицы
    {
        cout << invalidMatrixMessage << endl; //если некорректна, то ошибка

        n = -1;
        return nullptr;
    }

    return matrix;
}

/// <summary>
/// Метод считывания строк из текстового файла
/// </summary>
/// <param name="fileName">Имя файла</param>
/// <returns></returns>
vector<string> ReadLines(string fileName)
{
    const string fileNotFoundMessage = "Файл " + fileName + " не найден.";
    string path = "../" + fileName; //добавляем к началу имени файла, напрямую к файлу у exe почему-то не может дойти, проблема плюсов

    vector<string> lines; //считываемые строки
    ifstream file(path); //объект файла
    string line; //конкретная строка
    if (file.is_open()) //если файл открывается
    {
        while (getline(file, line)) //пока строки считываются
        {
            lines.push_back(line); //добавляем их в список строк
        }
        file.close(); //закрываем файл
    }
    else //иначе выводим ошибку
    {
        cout << fileNotFoundMessage << endl;
    }

    return lines;
}

/// <summary>
/// Метод считывания матрицы из текстового файла
/// </summary>
/// <param name="fileName">Имя файла</param>
/// <param name="n">Возвращаемая размерность матрицы</param>
/// <returns></returns>ы
double** ReadMatrix(string fileName, int& n)
{
    const string invalidMatrixMessage = "Некорректная матрица.";
    const char* separator = "\t"; //разделитель элементов в строке матрицы (табуляция)

    vector<string> lines = ReadLines(fileName); //считываем строки из файла в список
    int count = lines.size(); //количество строк
    n = count;
    double** matrix = new double*[count]; //итоговая матрица - двумерный динамический массив, выделяем ей память
    for (int i = 0; i < count; i++)
        matrix[i] = new double[count];

    for (int i = 0; i < lines.size(); i++) //проходим по всем строкам
    {
        //тут надо кучу манипуляций сделать для норм разделения, немного чистого си
        char* line = new char[lines.size() + 1]; //создаем объект сишной строки
        strcpy(line, lines[i].c_str()); //парсим в него нашу стринговую строку
        char* element = strtok(line, separator); //strtok возвращает часть строки до разделителя
        vector<string> elements; //список частей строки
        while (element != NULL) //пока получается достать методом strtok, там каретка перемещается при его вызове до разделителя, 
            //поэтому в какой-то момент дойдёт до конца строки и вернёт null
        {
            elements.push_back(element); //добавляем полученную часть строки в список
            element = strtok(NULL, separator); //достаем следующую часть строки
        }

        if (elements.size() != count) //если количество элементов в строке не равно количество строк, 
            //то матрица кривая, выводим сообщение об ошибке и выходим
        {
            cout << invalidMatrixMessage << endl;

            n = -1;
            return nullptr;
        }

        for (int j = 0; j < count; j++) //парсим полученные элементы строки в вещественные числа и добавляем в матрицу
        {
            double number = stod(elements[j]);
            matrix[i][j] = number;
        }

        elements.clear(); //опустошаем список для следющей строки
    }

    if (!CheckMatrix(matrix, n)) //проверка корректности полученной матрицы
    {
        cout << invalidMatrixMessage << endl; //если некорректна, то ошибка

        n = -1;
        return nullptr;
    }

    return matrix;
}

/// <summary>
/// Вывод матрицы на экран
/// </summary>
/// <param name="matrix">Матрица</param>
/// <param name="n">Размерность</param>
void ShowMatrix(double** matrix, int n)
{
    for (int i = 0; i < n; i++) //просто проходим по всем элементам и выводим
    {
        for (int j = 0; j < n; j++)
        {
            cout << matrix[i][j] << "\t";
        }
        cout << endl;
    }
    cout << endl;
}

/// <summary>
/// Структура, представляющая соединение элементов
/// </summary>
struct Connection
{
    int source; //индекс того, кто соединен
    int destination; //индекс того, с кем соединен
    double length; //длина соединения
};

/// <summary>
/// Метод вывода результата
/// </summary>
/// <param name="connections">Соединения</param>
void ShowResult(vector<Connection> connections)
{
    const string arrow = " <-> ";

    double sumLength = 0; //суммарная длина соединений
    for (int i = 0; i < connections.size(); i++) //проходим по всем соединениям и выводим их
    {
        cout << connections[i].source << arrow << connections[i].destination 
            << " [" << connections[i].length << "]" << endl;
        
        sumLength += connections[i].length; //при этом прибавляем их длину в сумму
    }

    cout << "L = " << sumLength << endl; //выводим сумму
}

/// <summary>
/// Метод, реализующий алгоритм Прима с оганичениями на степень локальных вершин
/// </summary>
/// <param name="matrix">Матрица смежности</param>
/// <param name="n">Размерность матрицы</param>
/// <param name="limitation">Ограничение</param>
/// <returns></returns>
vector<Connection> GetConnections(double** matrix, int n, int limitation)
{
    int count = n - 1; //количество полученных соединений на 1 меньше размерности матрицы

    vector<int> sourses = { 0 }; //изначально из первого элемента ищем соединение (строки по которым выбираем)
    vector<int> destinations; //в источниках все элементы, кроме первого (столбцы по которым выбираем)
    for (int i = 1; i < n; i++)
        destinations.push_back(i);

    int* connectionsNumbers = new int[n]; //количество имеющихся соединений у элементов, изначально 0
    for (int i = 0; i < n; i++)
        connectionsNumbers[i] = 0;

    vector<Connection> connections; //список полученных соединений
    while (destinations.size() > 0) //пока не будет элементов, в которые не заходит соединение (количество доступных столбцов)
    {
        double minLength = INT_MAX; //минимальная длина соединения на текущей итерации
        int minI = -1; //индекс по строкам (индекс источника)
        int minJ = -1; //индекс по столбцам (индекс получателя)
        for (int i = 0; i < sourses.size(); i++) //по всем источникам (по доступным строкам)
        {
            for (int j = 0; j < destinations.size(); j++) //по всем получателям (по доступным столбцам)
            {
                //ищем добавляемый элемент с минимальной длиной соединения
                int currentI = sourses[i]; //текущий индекс строки в матрице
                int currentJ = destinations[j]; ////текущий индекс столбца в матрице
                double currentElement = matrix[currentI][currentJ]; //текущее значение матрицы

                if(connectionsNumbers[currentI] < limitation) //если для этого элемента количество соединений меньше ограничения
                {
                    if (currentElement < minLength) //если длина меньше минимальной
                    {
                        minI = currentI; //то это новый добавляемый элемент
                        minJ = currentJ;
                        minLength = currentElement; 
                    }
                }
            }
        }

        Connection connection = { minI + 1, minJ + 1, minLength }; //добавляем соединение в список
        connections.push_back(connection);

        sourses.push_back(minJ); //добавляем значение столбца в список источников (доступных строк)
        destinations.erase(remove(destinations.begin(), destinations.end(), minJ), destinations.end()); //удаляем значение столбца 
            //из списка получателей (доступных столбцов)
        sort(sourses.begin(), sourses.end()); //сортируем список источников, просто чтобы проще было ручной расчет делать потом

        connectionsNumbers[minI]++; //увеличиваем источнику и получателю количество соединений
        connectionsNumbers[minJ]++;
    }
    delete[] connectionsNumbers; //очищаем память

    return connections;
}

int main(int argc, char* argv[]) //первый параметр - имя файла, второй - ограничение
{
    setlocale(LC_ALL, "RUSSIAN");
    const string invalidLimitationMessage = "Некорректное ограничение";
    
    string fileName = "matrix.txt"; //имя файла
    int limitation = 2;
    int n;
    double** matrix;
    if (argc > 1)
    {
        fileName = fileName = string(argv[1]);
        matrix = ReadMatrix(fileName, n);
    }
    else
    {
        matrix = InputMatrix(n);
    }

    if (n > 0) //если размерность нормальная, т.е. нет ошибки в методе считывания матрицы
    {
        if (argc > 2)
        {
            limitation = stoi(argv[2]);
        }
        else
        {
            cout << "Введите ограничение на локальные степени вершин: ";
            cin >> limitation;
        }

        if (limitation < 2) //если ограничение < 2, то оно некорректное, выводим сообщение
        {
            cout << invalidLimitationMessage << endl;
            return -1;
        }

        cout << "Матрица:" << endl; //то выводим матрицу
        ShowMatrix(matrix, n);

        cout << "Ограничение на локальные степени вершин: " << limitation << endl; //выводим ограничение

        vector<Connection> connections = GetConnections(matrix, n, limitation); //получаем соединения алгоритмом
        ShowResult(connections); //и выводим результат

        return 0;
    }
    else //иначе код ошибки возвращаем
    {
        return -1;
    }
}

