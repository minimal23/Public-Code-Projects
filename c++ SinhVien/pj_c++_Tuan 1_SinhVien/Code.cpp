#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <cstdlib>


#define MAX 5

typedef struct SinhVien
{
	char MSSV[10];
	char hoten[30];
	float diem1;
	float diem2;
	float diem3;
	float dtb;
};

void readfile(SinhVien arrSV[])
{
	FILE *fi = fopen("input.txt", "rt");

	if (fi == NULL)
	{
		printf("Khong doc duoc file");
		return;
	}
	else
	{
		int i = 0;
		while (!feof(fi))
		{
			fscanf(fi, "%s", &arrSV[i].MSSV);
			fscanf(fi, "%s", &arrSV[i].hoten);
			fscanf(fi, "%f", &arrSV[i].diem1);
			fscanf(fi, "%f", &arrSV[i].diem2);
			fscanf(fi, "%f", &arrSV[i].diem3);
			i++;
		}
		fclose(fi);
	}
}

void tinhdtb(SinhVien arrSV[])
{
	for (int i = 0; i < MAX; i++)
	{
		arrSV[i].dtb = (arrSV[i].diem1 + arrSV[i].diem2 + arrSV[i].diem3) / 3;
	}
}

void xuatdtb5(SinhVien arrSV[])
{
	for (int i = 0; i<MAX; i++)
	{	
		if (arrSV[i].dtb>=5)
		{
			printf("\n %s %s co DTB la %.2f", arrSV[i].MSSV, arrSV[i].hoten, arrSV[i].dtb);
		}		
	}
}
void xuatdsSV(SinhVien arrSV[])
{
	for (int i = 0; i<MAX; i++)
	{
		printf("\n %s %s co DTB la %.2f", arrSV[i].MSSV, arrSV[i].hoten, arrSV[i].dtb);
	}
}

/*bool operator * (const SinhVien &a, const SinhVien &b)
{
	return a.dtb > b.dtb;
}

int compare_dtb (const void * a, const void * b)
{
	return (*(SinhVien*)a * *(SinhVien*)b);
}
void sapxep(SinhVien arrSV[])
{
	int n = sizeof(arrSV) / sizeof(SinhVien);
	qsort(arrSV, n, sizeof(SinhVien), compare_dtb);
	printf("\n Danh sach sap xep tang dan theo dtb \n");
	for (int i = 0; i < n; i++)
	{
		printf("\n %s %s co DTB la %.2f", arrSV[i].MSSV, arrSV[i].hoten, arrSV[i].dtb);
	}
}*/
void main()
{
	SinhVien arrSV[MAX];
	readfile(arrSV);
	tinhdtb(arrSV);
	//xuatdsSV(arrSV);
	//xuatdtb5(arrSV);
	sapxep(arrSV);
	_getch();
}