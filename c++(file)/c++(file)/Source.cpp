#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <conio.h>
#define ESC '\x1b'
#define MAX 2

typedef struct hanghoa
{
	char mahang[10];
	char tenhang[30];
	int soluong;
	int dongia;
};

void nhap(hanghoa hh[], int i)
{
	i = 0;

	char c = '\0';
	printf("nhan ESC de ket thuc \n");
	while (i<MAX)
	{
		printf("\n nhap ma hang : ");
		scanf("%s",&hh[i].mahang);
		printf("\n nhap ten hang :");
		scanf("%s", &hh[i].tenhang);
		printf("\n nhap so luong :");
		scanf("%d", &hh[i].soluong);
		printf("\n nhap don gia :");
		scanf("%d", &hh[i].dongia);
		i++;
		//c=_getch();
	} 
}

void ghifile(hanghoa hh[])
{
	FILE* f1 = fopen("hanghoa.txt", "wt");
	if (f1 == NULL)
	{
		printf("ko doc dc file");
		return;
	}
	else
	{
		for (int i = 0; i < MAX; i++)
		{
			fprintf(f1, "%s\t", hh[i].mahang);
			fprintf(f1, "%s\t", hh[i].tenhang);
			fprintf(f1, "%d\t", hh[i].soluong);
			fprintf(f1, "%d\n", hh[i].dongia);
		}
	}
	fclose(f1);
}
void main()
{
	hanghoa hh[MAX];
	nhap(hh,MAX);
	ghifile(hh);
	_getch();
}