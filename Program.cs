//*****************************************************************************
//** 2981. Find Longest Special Substring That Occurs Thrice I    leetcode   **
//*****************************************************************************

int maximumLength(char* s)
{
    int lookup[26][3] = {0};
    int result = 0;
    int n = strlen(s);

    for (int i = 0, cnt = 0; i < n; i++)
    {
        cnt++;

        if (i + 1 < n && s[i + 1] == s[i])
        {
            continue;
        }

        int* curr = lookup[s[i] - 'a'];

        for (int j = 0; j < 3; j++)
        {
            if (curr[j] < cnt)
            {
                int temp = cnt;
                cnt = curr[j];
                curr[j] = temp;
            }
        }

        cnt = 0;

        int max1 = curr[0] - 2;
        int max2 = curr[0] - 1 < curr[1] ? curr[0] - 1 : curr[1];
        int max3 = curr[2];
        int maxCurr = max1 > max2 ? (max1 > max3 ? max1 : max3) : (max2 > max3 ? max2 : max3);
        result = result > maxCurr ? result : maxCurr;
    }

    return result ? result : -1;
}