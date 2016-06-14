//#define _CRT_SECURE_NO_WARNINGS
//
//#include <stdio.h>
//#include <conio.h>
//#include <string.h>
//#define MAX 10
//
//typedef struct SV
//{
//	int mssv;
//	char ho[15];
//	char ten[5];
//	float toan,ly,hoa, dtb;
//};
//
//typedef struct NODE 
//{
//	SV a[MAX];
//	NODE* pNext;
//};
//
//typedef struct LIST
//{
//	NODE* pHead;
//};
//
//void Initialize(LIST &list) 
//{
//	list.pHead = new NODE;
//}
//
//void readfile(LIST &list)
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
//		while (!feof(fi))
//		{
//			int i = 0;
//			NODE* p = list.pHead;
//			while (p != NULL) 
//			{
//				fscanf(fi, "%d", &p->a[i].mssv);
//				fscanf(fi, "%s", &p->a[i].ho);
//				fscanf(fi, "%s", &p->a[i].ten);
//				fscanf(fi, "%f", &p->a[i].toan);
//				fscanf(fi, "%f", &p->a[i].ly);
//				fscanf(fi, "%f", &p->a[i].hoa);
//				p = p->pNext;
//				i++;
//			}
//		}
//		fclose(fi);
//	}
//}
//
//void xuat(LIST list)
//{
//	int i = 0;
//	NODE* p = list.pHead;
//	while (p != NULL)
//	{
//		printf("\n%d %s %s %f %f %f",p->a[i].mssv,p->a[i].ho,p->a[i].ten, p->a[i].toan, p->a[i].ly, p->a[i].hoa);
//		p = p->pNext;
//		i++;
//	}
//}
//
//void main()
//{
//	LIST list;
//	Initialize(list);
//	readfile(list);
//	xuat(list);
//	_getch();
//}