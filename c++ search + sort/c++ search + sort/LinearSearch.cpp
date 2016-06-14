//#define _CRT_SECURE_NO_WARNINGS
//
//#include <stdio.h>
//#include <conio.h>
//
//int linear(int a[], int n, int x)
//{
//	for (int i = 0; i < n; i++)
//		if (x == a[i])
//			return i;
//	return -1;
//}
//
//void readfile(int a[])
//{
//	FILE *fi = fopen("input.txt", "rt");
//
//	if (fi == NULL)
//	{
//		printf("Khong doc duoc file");
//		return;
//	}
//	else
//	{
//		int i = 0;
//		while (!feof(fi))
//		{
//			fscanf(fi, "%d", &a[i]);
//			i++;
//		}
//		fclose(fi);
//	}
//}
//
//void main()
//{
//	int x;
//	int a[9];
//	readfile(a);
//	printf("nhap so can tim : ");
//	scanf("%d", &x);
//	printf ("so can tim o vi tri a[%d]", linear(a, sizeof(a) / sizeof(a[0]), x));
//	_getch();
//}