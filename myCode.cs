//Задача про алкашей
double[] limits = new double[4] {1.1, 2.5, 2.2, 3.3};
int durationWalk = 15;
int durationDrink = 15;

for (var i = 0; i < limits.Length; i++)
{
    Console.WriteLine($"Друг {i + 1}");
    Counting(limits[i], 0);
}

void Counting(double limit, int countPubs)
{
    if(limit - 0.57 > 0)
    {
        countPubs++;
        Counting(limit - 0.57, countPubs);
    }
    else
    {
        double resultDuration = durationDrink * countPubs;
        countPubs++;
        resultDuration += durationWalk * countPubs;
        resultDuration += (limit * durationDrink / 0.57);

        Console.WriteLine($"Потрачено времени в пустую до падения на дно: {Math.Round(resultDuration, 2)}");
        Console.WriteLine($"Столько пабов поспособствовало: {countPubs}");
    }
}

Console.WriteLine("-----------------------------------------------");
//Задача про взаимно простые числа
Console.Write("Число N: ");
int n = Convert.ToInt32(Console.ReadLine());

int[] numbers = new int[n];
for (var i = 0; i < numbers.Length; i++)
{
    numbers[i] = i + 1;
}

int countFreeNum = 0;
int countGroups = 0;

while(countFreeNum != n)
{
    //Console.WriteLine(countFreeNum);
    int[] tempArray = new int[1];
    if(countFreeNum == 0)
    {
        tempArray[0] = numbers[countFreeNum];
        numbers[countFreeNum] = 0;
        countFreeNum++;
        countGroups++;
        PrintArray(tempArray);
        continue;
    }
    for (var i = 0; i < numbers.Length; i++)
    {
        if(numbers[i] == 0)
        {
            continue;
        }
        if(tempArray.Length == 1 && tempArray[0] == 0)
        {
            tempArray[0] = numbers[i];
            numbers[i] = 0;
            countFreeNum++;
            continue;
        }
        else if(tempArray[0] != 0)
        {
            bool access = true;
            for (var j = 0; j < tempArray.Length; j++)
            {
                if(!Evklid(numbers[i], tempArray[j]))
                {
                    access = false;
                    break;
                }
            }
            if(access)
            {
                Array.Resize(ref tempArray, tempArray.Length + 1);
                tempArray[tempArray.Length - 1] = numbers[i];
                countFreeNum++;
                numbers[i] = 0;
            }
        }
    }
    countGroups++;
    PrintArray(tempArray);
}

void PrintArray(int[] array)
{
    Console.WriteLine($"Группа {countGroups}: ");
    for (var i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

bool Evklid(int m, int n)
{
    int nod;
    while(m != n)
    {
        if(m > n)
        {
            m -= n;
        }
        else
        {
            n -= m;
        }
    }
    nod = n;

    if(nod == 1)
    {
        return true;
    }
    else
    {
        return false;
    }
}
