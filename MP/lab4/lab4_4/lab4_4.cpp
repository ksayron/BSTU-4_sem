#include <iostream>
#include "LCS.h"    

int main()
{
    setlocale(LC_ALL, "rus");

    char z[100] = "";
    char x[] = "ABCBDAB",
        y[] = "BDCABA";

    int l = lcsd(x, y, z);
    std::cout << std::endl
        << "-- наибольшая общая подпоследовательость - LCS(динамическое"
        << "программирование)" << std::endl;
    std::cout << std::endl << "последовательость X: " << x;
    std::cout << std::endl << "последовательость Y: " << x;
    std::cout << std::endl << "                LCS: " << z;
    std::cout << std::endl << "          длина LCS: " << l;
    std::cout << std::endl;

    system("pause");
    return 0;
}
