using Database;
using MusicalInstrumentsDataBase.Models.Tables;

namespace MusicalInstrumentsDataBase.Models
{
    static class Sample
    {
        public static DbRowList<T> CheckDatas<T>(DbRowList<T> rows) where T : DbRow, new()
        {
            if (!IsAnyParameters())
            {
                return rows;
            }

            DbRowList<T> checkedRows = new DbRowList<T>(rows.TableName, rows.AddProcedure);

            foreach (DbRow row in rows.GetRows())
            {
                if (checkedRows.IsContains(row))
                {
                    continue;
                }

                int i = 0;
                object[] values = row.GetValues();
                bool isFits = false;

                foreach (CheckBox parametr in checkList.Keys)
                {
                    if (parametr.Checked)
                    {
                        if (checkList[parametr](values[columnsForCheckBox[parametr]]))
                        {
                            isFits = true;
                        }
                        else
                        {
                            isFits = false;
                            break;
                        }
                    }

                    i++;
                }

                if (isFits)
                {
                    checkedRows.Add(values);
                }
            }

            return checkedRows;
        }

        private static bool IsAnyParameters()
        {
            foreach (CheckBox parametr in checkList.Keys)
            {
                if (parametr.Checked)
                {
                    return true;
                }
            }

            return false;
        }

        private delegate bool CheckData(object obj);

        private static readonly Dictionary<CheckBox, CheckData> checkList;
        private static readonly Dictionary<CheckBox, int> columnsForCheckBox;

        public static CheckBox[] GetCheckBoxes()
        {
            return checkList.Keys.ToArray();
        }

        static Sample()
        {
            checkList = new Dictionary<CheckBox, CheckData>()
            {
                { new CheckBox() { Text = "Стоимость < 4 млн.", Dock = DockStyle.Top }, CheckData1 },
                { new CheckBox() { Text = "Стоимость 4 - 6 млн.", Dock = DockStyle.Top }, CheckData2 },
                { new CheckBox() { Text = "Стоимость > 6 млн.", Dock = DockStyle.Top }, CheckData3 },
                { new CheckBox() { Text = "Мощность дв. < 170 кВт", Dock = DockStyle.Top }, CheckData4 },
                { new CheckBox() { Text = "Мощность дв. 170 - 400 кВт", Dock = DockStyle.Top }, CheckData5 },
                { new CheckBox() { Text = "Мощность дв. > 400 кВт", Dock = DockStyle.Top }, CheckData6 },
                { new CheckBox() { Text = "Макс размер питания < 35 мм", Dock = DockStyle.Top }, CheckData7 },
                { new CheckBox() { Text = "Макс размер питания > 35 мм", Dock = DockStyle.Top }, CheckData8 },
                { new CheckBox() { Text = "Производительность < 200 т/ч", Dock = DockStyle.Top }, CheckData9 },
                { new CheckBox() { Text = "Производительность 200 - 500 т/ч", Dock = DockStyle.Top }, CheckData10 },
                { new CheckBox() { Text = "Производительность > 500 т/ч", Dock = DockStyle.Top }, CheckData11 },
                { new CheckBox() { Text = "Масса < 10 т", Dock = DockStyle.Top }, CheckData12 },
                { new CheckBox() { Text = "Масса > 10 т", Dock = DockStyle.Top }, CheckData13 },
                { new CheckBox() { Text = "Кол-во двигателей = 1", Dock = DockStyle.Top }, CheckData14 },
                { new CheckBox() { Text = "Кол-во двигателей = 2", Dock = DockStyle.Top }, CheckData15 },
                { new CheckBox() { Text = "Кол-во двигателей = 3", Dock = DockStyle.Top }, CheckData16 },
                { new CheckBox() { Text = "Оценка >= 3", Dock = DockStyle.Top }, CheckData17 },
                { new CheckBox() { Text = "Оценка >= 4", Dock = DockStyle.Top }, CheckData18 },
                { new CheckBox() { Text = "Оценка = 5", Dock = DockStyle.Top }, CheckData19 },
                { new CheckBox() { Text = "Произведено в США", Dock = DockStyle.Top }, CheckData20 },
                { new CheckBox() { Text = "Произведено в России", Dock = DockStyle.Top }, CheckData21 },
                { new CheckBox() { Text = "Произведено в Китае", Dock = DockStyle.Top }, CheckData22 },
                { new CheckBox() { Text = "Произведено в Германии", Dock = DockStyle.Top }, CheckData23 },
                { new CheckBox() { Text = "Типа Конусная", Dock = DockStyle.Top }, CheckData24 },
                { new CheckBox() { Text = "Типа Мельница аэробильная", Dock = DockStyle.Top }, CheckData25 },
                { new CheckBox() { Text = "Типа Молотковая", Dock = DockStyle.Top }, CheckData26 },
                { new CheckBox() { Text = "Типа Центробежная", Dock = DockStyle.Top }, CheckData27 },
                { new CheckBox() { Text = "Типа Щековая", Dock = DockStyle.Top }, CheckData28 },
                { new CheckBox() { Text = "Типа Валковая", Dock = DockStyle.Top }, CheckData29 },
                { new CheckBox() { Text = "Длина < 3 тыс.", Dock = DockStyle.Top }, CheckData30 },
                { new CheckBox() { Text = "Длина 3 - 10 тыс.", Dock = DockStyle.Top }, CheckData31 },
                { new CheckBox() { Text = "Длина > 10 тыс.", Dock = DockStyle.Top }, CheckData32 },
                { new CheckBox() { Text = "Ширина < 3 тыс.", Dock = DockStyle.Top }, CheckData33 },
                { new CheckBox() { Text = "Ширина 3 - 10 тыс.", Dock = DockStyle.Top }, CheckData34 },
                { new CheckBox() { Text = "Ширина > 10 тыс.", Dock = DockStyle.Top }, CheckData35 },
                { new CheckBox() { Text = "Высота < 3 тыс.", Dock = DockStyle.Top }, CheckData36 },
                { new CheckBox() { Text = "Высота 3 - 10 тыс.", Dock = DockStyle.Top }, CheckData37 },
                { new CheckBox() { Text = "Высота > 10 тыс.", Dock = DockStyle.Top }, CheckData38 },
            };

            CheckBox[] checkBoxes = checkList.Keys.ToArray();

            columnsForCheckBox = new Dictionary<CheckBox, int>()
            {
                { checkBoxes[0], 1 },
                { checkBoxes[1], 1 },
                { checkBoxes[2], 1 },
                { checkBoxes[3], 2 },
                { checkBoxes[4], 2 },
                { checkBoxes[5], 2 },
                { checkBoxes[6], 3 },
                { checkBoxes[7], 3 },
                { checkBoxes[8], 4 },
                { checkBoxes[9], 4 },
                { checkBoxes[10], 4 },
                { checkBoxes[11], 5 },
                { checkBoxes[12], 5 },
                { checkBoxes[13], 6 },
                { checkBoxes[14], 6 },
                { checkBoxes[15], 6 },
                { checkBoxes[16], 7 },
                { checkBoxes[17], 7 },
                { checkBoxes[18], 7 },
                { checkBoxes[19], 8 },
                { checkBoxes[20], 8 },
                { checkBoxes[21], 8 },
                { checkBoxes[22], 8 },
                { checkBoxes[23], 9 },
                { checkBoxes[24], 9 },
                { checkBoxes[25], 9 },
                { checkBoxes[26], 9 },
                { checkBoxes[27], 9 },
                { checkBoxes[28], 9 },
                { checkBoxes[29], 10 },
                { checkBoxes[30], 10 },
                { checkBoxes[31], 10 },
                { checkBoxes[32], 11 },
                { checkBoxes[33], 11 },
                { checkBoxes[34], 11 },
                { checkBoxes[35], 12 },
                { checkBoxes[36], 12 },
                { checkBoxes[37], 12 }
            };
        }

        private static bool CheckData38(object obj)
        {
            int large = (int)obj;
            return large > 10000;
        }

        private static bool CheckData37(object obj)
        {
            int large = (int)obj;
            return large > 3000 && large < 10000;
        }

        private static bool CheckData36(object obj)
        {
            int large = (int)obj;
            return large < 3000;
        }

        private static bool CheckData35(object obj)
        {
            int large = (int)obj;
            return large > 10000;
        }

        private static bool CheckData34(object obj)
        {
            int large = (int)obj;
            return large > 3000 && large < 10000;
        }

        private static bool CheckData33(object obj)
        {
            int large = (int)obj;
            return large < 3000;
        }

        private static bool CheckData32(object obj)
        {
            int large = (int)obj;
            return large > 10000;
        }

        private static bool CheckData31(object obj)
        {
            int large = (int)obj;
            return large > 3000 && large < 10000;
        }

        private static bool CheckData30(object obj)
        {
            int large = (int)obj;
            return large < 3000;
        }

        private static bool CheckData29(object obj)
        {
            string type = (string)obj;
            return type == "валковая";
        }

        private static bool CheckData28(object obj)
        {
            string type = (string)obj;
            return type == "щековая";
        }

        private static bool CheckData27(object obj)
        {
            string type = (string)obj;
            return type == "центробежная";
        }

        private static bool CheckData26(object obj)
        {
            string type = (string)obj;
            return type == "молотковая";
        }

        private static bool CheckData25(object obj)
        {
            string type = (string)obj;
            return type == "мельница аэробильная";
        }

        private static bool CheckData24(object obj)
        {
            string type = (string)obj;
            return type == "конусная";
        }

        private static bool CheckData23(object obj)
        {
            string side = (string)obj;

            if (side == "Германия")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData22(object obj)
        {
            string side = (string)obj;

            if (side == "Китай")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData21(object obj)
        {
            string side = (string)obj;

            if (side == "Россия")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData20(object obj)
        {
            string side = (string)obj;

            if (side == "США")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData19(object obj)
        {
            int grad = (int)obj;

            if (grad == 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData18(object obj)
        {
            int grad = (int)obj;

            if (grad >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData17(object obj)
        {
            int grad = (int)obj;

            if (grad >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData16(object obj)
        {
            int count = (int)obj;

            if (count == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData15(object obj)
        {
            int count = (int)obj;

            if (count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData14(object obj)
        {
            int count = (int)obj;

            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData13(object obj)
        {
            int mass = (int)obj;

            if (mass > 10000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData12(object obj)
        {
            int mass = (int)obj;

            if (mass < 10000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData11(object obj)
        {
            int performance = (int)obj;

            if (performance > 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData10(object obj)
        {
            int performance = (int)obj;

            if (performance > 200 && performance < 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData9(object obj)
        {
            int performance = (int)obj;

            if (performance < 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData8(object obj)
        {
            int size = (int)obj;

            if (size > 35)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData7(object obj)
        {
            int size = (int)obj;

            if (size < 35)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData6(object obj)
        {
            int power = (int)obj;

            if (power > 400)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData5(object obj)
        {
            int power = (int)obj;

            if (power > 170 && power < 400)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData4(object obj)
        {
            int power = (int)obj;

            if (power < 170)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData3(object obj)
        {
            int coast = (int)obj;

            if (coast > 6000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData1(object obj)
        {
            int coast = (int)obj;

            if (coast < 4000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckData2(object obj)
        {
            int coast = (int)obj;

            if (coast > 4000000 && coast < 6000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
