﻿string filePath = "test.txt";
FileInfo fi = new FileInfo(filePath);

if(!fi.Exists)
{
    Console.WriteLine("oops file not exists");
}

using (FileStream fs = new FileStream(filePath, FileMode.Open))
{
    // 

    int bufferSize = 4096;

    byte[] buffer = new byte[bufferSize];

    for (int j = 0; j < 3; j++)
    {
        fs.Seek(bufferSize * j, SeekOrigin.Begin);
        await fs.ReadAsync(buffer);

        for (int i = 0; i < buffer.Length; i++)
        {
            Console.Write((char)buffer[i]);
        }
    }
}
