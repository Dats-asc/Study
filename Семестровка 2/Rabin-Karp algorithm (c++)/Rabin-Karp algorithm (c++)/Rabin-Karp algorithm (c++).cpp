#include <iostream>

using namespace std;

int hash(string a)
{
    int hash = a[0];
    for (int i = 1; i < a.length(); i++)
    {
        hash += a[i] * (int)pow(10, i);
    }
    return hash;
}

bool algorithm(string text, string pattern, int patternHash)
{
    for (int i = 0; i <= text.length() - pattern.length(); i++)
    {
        if (::hash(text.substr(i, pattern.length())) == patternHash)
        {
            int count = 0;
            for (int j = i; j <= j + 3; j++)
            {
                if (text[j] != pattern[count])
                    break;
            }
            return true;
        }
    }
    return false;
}

int main()
{
    string text = "Hello world";
    string pattern = "world11";
    cout << algorithm(text, pattern, ::hash(pattern));
}