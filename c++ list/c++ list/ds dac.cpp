//#define _CRT_SECURE_NO_WARNINGS
//
//#include <stdio.h>
//#include <conio.h>
//#include <string.h>
//#define MAX 10
//
//typedef struct sv
//{
//	char ho[10];
//	char ten[5];
//	int mssv;
//	float toan, ly, hoa, dtb;
//};
//
//typedef struct clist 
//{
//	int n;
//	sv a[MAX];
//};
//
//
//void init(clist &list)
//{
//	list.n = 10;
//}
//
//void readfile(clist &list)
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
//			fscanf(fi, "%d", &list.a[i].mssv);
//			fscanf(fi, "%f", &list.a[i].toan);
//			fscanf(fi, "%f", &list.a[i].ly);
//			fscanf(fi, "%f", &list.a[i].hoa);
//			fscanf(fi, "%s", &list.a[i].ho);
//			fscanf(fi, "%s", &list.a[i].ten);
//			i++;
//		}
//		fclose(fi);
//	}
//}
//
//void xuat_list(clist list)
//{
//	for (int i = 0; i < list.n; i++)
//			printf("\n%d %s %s %.2f %.2f %.2f", list.a[i].mssv, list.a[i].ho, list.a[i].ten, list.a[i].toan, list.a[i].ly, list.a[i].hoa);
//}
//
//void tim_sv_toan_be_8(clist list)
//{
//	printf("\nsv co toan < 8 la :");
//	for (int i = 0; i < list.n; i++)
//		if (list.a[i].toan < 8)
//			printf("\n%d %s %s %.2f %.2f %.2f", list.a[i].mssv, list.a[i].ho, list.a[i].ten, list.a[i].toan, list.a[i].ly, list.a[i].hoa);
//}
//
//void tinh_dtb(clist &list)
//{
//	for (int i = 0; i < list.n; i++)
//		list.a[i].dtb = (list.a[i].toan + list.a[i].ly + list.a[i].hoa) / 3;
//}
//
//void dem_sv_dtb_lon_7(clist list) 
//{
//	int count = 0;
//	for (int i = 0; i < list.n; i++)
//		if (list.a[i].dtb > 7)
//			count++;
//	printf("\nSo sv co dtb > 7 la : %d", count);
//}
//
//void tim_sv_ly_max(clist list)
//{
//	float max = 0;
//	int pos;
//	for (int i = 0; i < list.n; i++)
//	{
//		if (list.a[i].ly > max)
//		{
//			max = list.a[i].ly;
//			pos = i;
//		}
//	}
//	printf("\nSV co diem ly max la : %d %s %s %.2f %.2f %.2f", list.a[pos].mssv, list.a[pos].ho, list.a[pos].ten, list.a[pos].toan, list.a[pos].ly, list.a[pos].hoa);
//}
//
//bool IsEmpty(clist list) 
//{
//	if (list.n == 0) 
//		return true;
//	return false;
//}
//
//bool IsFull(clist list) 
//{
//	if (list.n == 10) return true;
//	return false;
//}
//
//bool Delete_mssv(clist &list) 
//{
//	int k;
//	int x;
//	printf("\nNhap mssv can xoa :");
//	scanf("%d", &x);
//	for (int i = 0; i < list.n; i++)
//	{
//		if (list.a[i].mssv == x)
//			k = i;
//	}
//	if (!IsEmpty(list) && (0 <= k && k < list.n)) 
//	{
//		for (int i = k; i < list.n - 1; i++) 
//		{
//			list.a[i] = list.a[i + 1];
//		}
//		list.n--;
//		return true;
//	}
//	return false;
//}
//
//bool Insert(clist &list) 
//{
//	int k;
//	printf("\nNhap vi tri muon them : ");
//	scanf("%d", &k);
//	if (!IsFull(list) && (0 <= k && k <= list.n)) 
//	{
//		for (int i = list.n; i > k; i--) 
//		{
//			list.a[i] = list.a[i - 1];
//		}
//		printf("\nNhap mssv : ");
//		scanf("%d", &list.a[k].mssv);
//		printf("\nNhap ho : ");
//		scanf("%s", &list.a[k].ho);
//		printf("\nNhap ten : ");
//		scanf("%s", &list.a[k].ten);
//		printf("\nNhap diem toan : ");
//		scanf("%f", &list.a[k].toan);
//		printf("\nNhap diem ly : ");
//		scanf("%f", &list.a[k].ly);
//		printf("\nNhap diem hoa : ");
//		scanf("%f", &list.a[k].hoa);
//		list.n++;
//		return true;
//	}
//	return false;
//}
//
//bool Delete_hoa_be_6(clist &list)
//{
//	int k=0;
//	for (int i = 0; i < list.n; i++)
//	{
//		if (list.a[i].hoa < 6)
//			k = i;
//	}
//	if (!IsEmpty(list) && (0 <= k && k < list.n))
//	{
//		for (int i = k; i < list.n - 1; i++)
//		{
//			list.a[i] = list.a[i + 1];
//		}
//		list.n--;
//		return true;
//	}
//	return false;
//}
//
//void main()
//{
//	clist list;
//	init(list);
//	readfile(list);
//	xuat_list(list);
//	printf("\n");
//	//tim_sv_toan_be_8(list);
//	//tinh_dtb(list);
//	//dem_sv_dtb_lon_7(list);
//	//tim_sv_ly_max(list);
//	//Delete_mssv(list);
//	//Insert(list);
//	Delete_hoa_be_6(list);
//	xuat_list(list);
//	_getch();
//}