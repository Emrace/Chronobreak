#include <iostream>

using namespace std;

void sortArray(int arr[20], int length)
{
	int counter = length;
	bool flag = true;

	for (int i = 0; i < length && flag; i++)
	{
		flag = false;

		for (int j = 0; j < length - i - 1; j++)
		{
			if (arr[j + 1] < arr[j])
			{
				int temp = arr[j + 1];
				arr[j + 1] = arr[j];
				arr[j] = temp;
				flag = true;
			}
		}
	}
}

void printArray(int arr[20], int length)
{
	for (int i = 0; i < length; i++)
	{
		cout << arr[i] << " ";
	}
}

int main()
{
	int arr[10] = { 7,2,4,6,3,8,120,0,-4,15 };
	sortArray(arr, 10);
	printArray(arr, 10);

	system("pause");
	return 0;
}