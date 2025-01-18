Queue<int> contestants = new(Console.ReadLine()!.Split(' ').Select(int.Parse));
Stack<int> pies = new(Console.ReadLine()!.Split(' ').Select(int.Parse));

while (true)
{
    int currentContestant = contestants.Peek(); // Represents their max eating possibilities
    int currentPie = pies.Peek();

    if (currentContestant > currentPie)
    {
        pies.Pop();
        contestants.Enqueue(contestants.Dequeue() - currentPie);
    }
    else
    {
        currentPie -= currentContestant;
        contestants.Dequeue();
        if (currentPie == 0)
        {
            pies.Pop();
            if (pies.Count == 0 || contestants.Count == 0) break;
            continue;
        }
        if (pies.Count != 0)
        {
            pies.Pop();
            pies.Push(currentPie);
        }
        if (currentPie == 1)
        {
            if (pies.Count > 1)
            {
                pies.Pop();
                pies.Push(pies.Pop() + 1);
            }
        }
    }

    if (pies.Count == 0 || contestants.Count == 0) break;
}

if (contestants.Count == 0 && pies.Count == 0) Console.WriteLine("We have a champion!");
else if (contestants.Count == 0) Console.WriteLine($"Our contestants need to rest!{Environment.NewLine}Pies left: {string.Join(", ", pies)}");
else if (pies.Count == 0)
    Console.WriteLine($"We will have to wait for more pies to be baked!{Environment.NewLine}Contestants left: {string.Join(", ", contestants)}");