using System.Text;

HttpClient client = new HttpClient();

HttpResponseMessage response = await client.GetAsync("https://localhost:7280/Auth/Register");

Stream responseStream = await response.Content.ReadAsStreamAsync();

string json = "";

int position = 0;
byte[] buffer = new byte[1024];

while (position < responseStream.Length)
{
    long bytesLeft = responseStream.Length - position;
    int readBytes = bytesLeft < buffer.Length 
        ? (int)bytesLeft 
        : buffer.Length;
    int receivedBytes = await responseStream.ReadAsync(buffer, 0, readBytes);

    string partOfJson = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
    json += partOfJson;

    position += buffer.Length;
    responseStream.Seek(position, SeekOrigin.Current);
}

Console.WriteLine();