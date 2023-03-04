using OzoneTechAlgorithm.Interface;

namespace OzoneTechAlgorithm.Sandbox
{
    internal class D : MainInterface
    {
        /// <summary>
        /// Все тесты, кроме 8 - 10 проходят.
        /// Последние не проходят, как я думаю, из-за несоблюдения мной этого условия:
        /// При этом, если у двух строк одинаковое значение в этом столбце, то относительный порядок строк не изменится.
        /// Как его соблюсти я пока не знаю.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string[] MainMethod(string[] input)
        {

            List<string> list = new List<string>();
            int capacity = int.Parse(input[0]);
            int count = 0;
            int rows, columns;

            for (int i = 2; count < capacity; i = i + 4 + rows)
            {
                string[] str_table = input[i].Split(' ');
                rows = Convert.ToInt32(str_table[0]);
                columns = Convert.ToInt32(str_table[1]);
                int[,] table = new int[rows, columns];

                string[] row;
                for (int r = 0; r < rows; r++)
                {
                    row = input[i + 1 + r].Split(' ');
                    for (int c = 0; c < columns; c++)
                    {
                        table[r, c] = Convert.ToInt32(row[c]);
                    }
                }

                string[] clickCol = input[i + rows + 2].Split(' ').ToArray();
                int temp, tempCol;

                for (int f = 0; f < clickCol.Length; f++)
                {
                    int col = Convert.ToInt32(clickCol[f]) - 1;
                    if (f > 0)
                    {
                        //пропускаем если в предыдущем шаге уже сортировали этот столбец
                        if (col == Convert.ToInt32(clickCol[f - 1])) continue;
                    }

                    for (int rov = 0; rov < rows; rov++)
                    {
                        for (int rov2 = rov + 1; rov2 < rows; rov2++)
                        {
                            if (table[rov, col] > table[rov2, col])
                            {
                                temp = table[rov, col];
                                table[rov, col] = table[rov2, col];
                                table[rov2, col] = temp;

                                for (int p = 0; p < columns; p++)
                                {
                                    if (p == col) continue;
                                    temp = table[rov, p];
                                    table[rov, p] = table[rov2, p];
                                    table[rov2, p] = temp;
                                }
                            }
                        }
                    }
                }
                for (int u = 0; u < rows; u++)
                {
                    string temp_arr = "";
                    for (int p = 0; p < columns; p++)
                    {
                        temp_arr += table[u, p].ToString();
                        if (p + 1 != columns) temp_arr += " ";
                    }
                    list.Add(temp_arr);
                }
                list.Add("");
                count++;
            }

            return list.ToArray();
        }
    }
}
