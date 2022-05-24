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
