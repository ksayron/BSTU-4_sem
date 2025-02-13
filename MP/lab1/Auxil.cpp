#include "Auxil.h"

void auxil::start() {
    srand(time(0));
}

int auxil::iget(int imin, int imax)
{
    return (rand() % (imax - imin))+imin;
}

double auxil::dget(double dmin, double dmax)
{
    return ((rand()) % int(dmax - dmin)) + int(dmin) + double(rand() % 10)/10;
}

