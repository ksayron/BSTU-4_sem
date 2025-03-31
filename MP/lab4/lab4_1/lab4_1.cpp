#include <iostream>
#include <random>
#include <string>

std::string generate(int length) {
    std::string nabor = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    std::string result;
    for (int i = 0; i < length; ++i) {
        result += nabor[rand() % nabor.size()];
    }

    return result;
}

int main() {
    std::string S1 = generate(300);
    std::string S2 = generate(200);

    std::cout << "S1: " << S1 << std::endl;
    std::cout << "S2: " << S2 << std::endl;

    return 0;
}