#include <iostream>
#include "LCS.h"
int main()
{
    setlocale(LC_ALL, "rus");
    char X[] = "ALDC", Y[] = "LADCM";
    std::cout << std::endl << "-- вычисление длины LCS для X и Y(рекурсия)";
    std::cout << std::endl << "-- последовательность X: " << X;
    std::cout << std::endl << "-- последовательность Y: " << Y;
    int s = lcs(
        sizeof(X) - 1,  // длина   последовательности  X   
        "ALDC",       // последовательность X
        sizeof(Y) - 1,  // длина   последовательности  Y
        "LADCM"       // последовательность Y
    );
    std::cout << std::endl << "-- длина LCS: " << s << std::endl;
    system("pause");
    return 0;
}
