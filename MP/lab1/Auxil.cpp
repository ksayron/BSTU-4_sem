#include "Auxil.h"

void start() {
    srand(time(0));
}

int auxil::iget(int imin, int imax)
{
    return (rand() % (imax - imin))+imin;
}

double auxil::dget(double dmin, double dmax)
{
    return ((rand()) % (dmax - dmin)) + dmin;
}
