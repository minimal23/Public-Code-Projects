//#define _CRT_SECURE_NO_WARNINGS
//
//#include <stdio.h>
//#include <conio.h>
//
//int Binary(int a[], int n, int x)
//{
//	int left = 0;
//	int right = n - 1;
//	while (left <= right)
//	{
//		int mid = (left + right) / 2;
//		if (x == a[mid])
//			return mid;
//		else if (x < a[mid])
//			right = mid - 1;
//		else if (x > a[mid])
//			left = mid + 1;
//	}
//	return -1;
//}
//
//int Binary(int a[], int left, int right, int x)
//{
//	if (left > right)
//		return -1;
//	int mid = (left + right) / 2;
//	if (x == a[mid])
//		return mid;
//	if (x < a[mid])
//		return Binary(a, left, mid - 1, x);
//	if (x > a[mid])
//		return Binary(a, mid + 1, right, x);
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
//void swap(int &x, int &y) 
//{ 
//	int t = x;    
//	x = y;   
//	y = t; 
//}
//
//void bbsort(int a[], int n)
//{
//	int i, j;
//	for (int i = 0; i < n - 1; i++)
//		for (j = n - 1; j > i; j--)
//			if (a[j] < a[j - 1])
//				swap(a[j], a[j - 1]);
//}
//
//void main()
//{
//	int x;
//	int a[9];
//	readfile(a);
//	printf("nhap so can tim : ");
//	scanf("%d", &x);
//	bbsort(a, sizeof(a) / sizeof(a[0]));
//	for (int i = 0; i < 9; i++)
//		printf("%d\t", a[i]);
//	printf("\n[ko de qui] so can tim o vi tri a[%d]\n", Binary(a, (sizeof(a) / sizeof(a[0])), x));
//	printf("[de qui] so can tim o vi tri a[%d]", Binary(a, 0, ((sizeof(a) / sizeof(a[0])) - 1), x));
//	_getch();
//}