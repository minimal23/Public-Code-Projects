#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <conio.h>

float tongphanso2(int n)
{
	if (n == 1)
		return 0;
	else
		return tongphanso2(n - 1) + (float)1 / (n*(n - 1));
}

void main()
{
	int n;
	printf("nhap n : ");
	scanf("%d", &n);
	printf("so luong chu so cua n la : %.2f ", tongphanso2(n));
	_getch();
}
