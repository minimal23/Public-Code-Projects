#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <conio.h>
#include <string.h>
#define MAX 10

typedef struct sach
{
	char masach[7];
	char tensach[15];
	int gia;
};

typedef struct cqueue 
{
	int count;
	int front;
	int rear;
	sach a[MAX];
};

void init(cqueue &q, int &n)
{
	q.count = n;
	q.front = 0;
	q.rear = q.count;
}
	
bool IsFull(cqueue q) 
{
	if (q.count == MAX)
		return true;
	return false;
}

bool IsEmpty(cqueue q)
{
	if (q.count == 0)
		return true;
	return false;
}

bool Push(cqueue &q, sach s) 
{
	if (!IsFull(q)) 
	{
		q.rear = (q.rear + 1) % MAX;
		q.a[q.rear] = s;
		q.count++;
		return true;
	}
	return false;
}

sach Pop(cqueue &q) 
{
	if (!IsEmpty(q)) 
	{
		sach s = q.a[q.front];
		q.front = (q.front + 1) % MAX;
		q.count--;
		return s;
	}
}

sach GetFront(cqueue q) 
{
	if (!IsEmpty(q)) 
	{
		sach s = q.a[q.front];
		return s;
	}
}

sach GetRear(cqueue q) 
{
	if (!IsEmpty(q)) 
	{
		sach s = q.a[q.rear];
		return s;
	}
}

void nhap(cqueue &q)
{
	for (int i = q.front; i < q.rear; i++)
	{
		printf("nhap ma sach : ");
		scanf("%s", &q.a[i].masach);
		printf("nhap ten sach : ");
		scanf("%s", &q.a[i].tensach);
		printf("nhap gia sach : ");
		scanf("%d", &q.a[i].gia);
	}
}

void xuat(cqueue q)
{
	for (int i = q.front; i < q.rear; i++)
	{
		printf("\n%s %s %d", q.a[i].masach, q.a[i].tensach, q.a[i].gia);
	}
}

void tim(cqueue q)
{
	int pos = -1;
	char* x = new char[15];
	go :
	printf("\nnhap ten sach can tim : ");
	scanf("%s", x);
	for (int i = q.front; i < q.rear; i++)
	{
		if (strcmp(q.a[i].tensach, x) == 0)
			pos = i;
	}
	if (pos != -1)
		printf("\n%s %s %d", q.a[pos].masach, q.a[pos].tensach, q.a[pos].gia);
	else
	{
		printf("ko co sach can tim");
		goto go;
	}
}

void main()
{
	int n;
	printf("nhap n :");
	scanf("%d", &n);
	cqueue q;
	init(q, n);
	nhap(q);
	//xuat(q);
	tim(q);
	_getch();
}