#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <conio.h>
#include <string.h>
#include <ctype.h>
#define MAX 5

typedef struct sv
{
	char mssv[5];
	char hoten[30];
	float d1, d2, d3, dtb;
};

void readfile(sv arrSV[])
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
			fscanf(fi, "%s", &arrSV[i].mssv);
			fscanf(fi, "%s", &arrSV[i].hoten);
			fscanf(fi, "%f", &arrSV[i].d1);
			fscanf(fi, "%f", &arrSV[i].d2);
			fscanf(fi, "%f", &arrSV[i].d3);
			i++;
		}
		fclose(fi);
	}
}

void xuatdsSV(sv arrSV[])
{
	for (int i = 0; i<MAX; i++)
	{
		printf("\n%s %s %.2f %.2f %.2f %.2f", arrSV[i].mssv, arrSV[i].hoten, arrSV[i].d1, arrSV[i].d2,arrSV[i].d3, arrSV[i].dtb);
	}
}

void tim_sapxep(sv arrSV[])
{
	sv t;
	for (int i = 0; i < MAX - 1; i++)
	{
		for (int j = MAX - 1; j > i; j--)
			if (arrSV[j].d1 < arrSV[j - 1].d1)
			{
				t = arrSV[j];
				arrSV[j] = arrSV[j - 1];
				arrSV[j - 1] = t;
			}
	}
	for (int k = 0; k < MAX; k++)
	{
		if (arrSV[k].d1 < 5)
			printf("%s %s %.2f %.2f %.2f\n", arrSV[k].mssv, arrSV[k].hoten, arrSV[k].d1, arrSV[k].d2, arrSV[k].d3);
	}
}

void tim_ho_N(sv arrSV[])
{
	for (int i = 0; i < MAX; i++)
	{
		if (strncmp (arrSV[i].hoten,"N",1) == 0 )
			printf("\n%s %s %.2f %.2f %.2f\n", arrSV[i].mssv, arrSV[i].hoten, arrSV[i].d1, arrSV[i].d2, arrSV[i].d3);
	}
}

void tim_dtb_max(sv arrSV[])
{
	float max = 0;
	sv t;
	int pos;
	for (int i = 0; i < MAX; i++)
	{
		arrSV[i].dtb = (arrSV[i].d1 + arrSV[i].d2 + arrSV[i].d3) / 3;
	}
	for (int i = 0; i < MAX; i++)
	{
		if (arrSV[i].dtb > max)
		{
			max = arrSV[i].dtb;
			pos = i;
		}
	}
	printf("SV co dtb max la :  %s %s dtb = %.2f",arrSV[pos].mssv,arrSV[pos].hoten,arrSV[pos].dtb);
}

void sapxep_hoten_giam(sv arrSV[])
{
	sv t;
	for (int i = 0; i < MAX - 1; i++)
	{
		for (int j=i+1;j<MAX;j++)
			if (strcmp(arrSV[i].hoten,arrSV[j].hoten) <0)
			{
				t = arrSV[j];
				arrSV[j] = arrSV[i];
				arrSV[i] = t;
			}
	}
}

void sx_dtb_giam_mssv_tang(sv arrSV[])
{
	sv t;
	for (int i = 0; i < MAX - 1; i++)
	{
		for (int j = MAX - 1; j > i; j--)
			if (arrSV[j].dtb > arrSV[j - 1].dtb)
			{
				t = arrSV[j];
				arrSV[j] = arrSV[j - 1];
				arrSV[j - 1] = t;
			}
	}
}

void main()
{
	sv a[MAX];
	readfile(a);
	//tim_sapxep(a);
	//xuatdsSV(a);
	//tim_ho_N(a);
	tim_dtb_max(a);
	//sapxep_hoten_giam(a);
	sx_dtb_giam_mssv_tang(a);
	xuatdsSV(a);
	_getch();
}