using Database;
using MusicalInstrumentsDataBase.Models.Tables;

namespace MusicalInstrumentsDataBase.Models
{
    static class Sample
    {
        public static DbRowList<T> CheckDatas<T>(DbRowList<T> rows) where T : DbRow, new()
        {
            DbRowList<T> checkedRows = new DbRowList<T>(rows.TableName, rows.AddProcedure);

            foreach (DbRow row in rows.GetRows())
            {
                if (checkedRows.IsContains(row))
                {
                    continue;
                }

                object[] values = row.GetValues();
                bool isFits = false;

                foreach (int column in checkList.Keys)
                {
                    if (checkList[column](values[column]))
                    {
                        isFits = true;
                    }
                    else
                    {
                        isFits = false;
                        break;
                    }
                }

                if (isFits)
                {
                    checkedRows.Add(values);
                }
            }

            return checkedRows;
        }

        public static NumericUpDown coastStartNumericUpDown { get; set;}
        public static NumericUpDown coastEndNumericUpDown { get; set; }

        public static NumericUpDown powerStartNumericUpDown { get; set; }
        public static NumericUpDown powerEndNumericUpDown { get; set; }

        public static NumericUpDown maxSizeStartNumericUpDown { get; set; }
        public static NumericUpDown maxSizeEndNumericUpDown { get; set; }

        public static NumericUpDown performanceStartNumericUpDown { get; set; }
        public static NumericUpDown performancEndNumericUpDown { get; set; }

        public static NumericUpDown massStartNumericUpDown { get; set; }
        public static NumericUpDown massEndNumericUpDown { get; set; }

        public static NumericUpDown numberEnginesStartNumericUpDown { get; set; }
        public static NumericUpDown numberEnginesEndNumericUpDown { get; set; }

        public static CheckedListBox stateСheckedListBox { get; set; }
        public static CheckedListBox typeСheckedListBox { get; set; }

        public static NumericUpDown lengthStartNumericUpDown { get; set; }
        public static NumericUpDown lengthEndNumericUpDown { get; set; }

        public static NumericUpDown widthStartNumericUpDown { get; set; }
        public static NumericUpDown widthEndNumericUpDown { get; set; }

        public static NumericUpDown hightStartNumericUpDown { get; set; }
        public static NumericUpDown hightEndNumericUpDown { get; set; }

        private static readonly Dictionary<int, CheckData> checkList = new Dictionary<int, CheckData>()
        {
                { 1, CheckDataCoast },
                { 2, CheckDataPower },
                { 3, CheckDataMaxSize },
                { 4, CheckDataPerformance },
                { 5, CheckDataMass },
                { 6, CheckDataNumberEngines },
                { 7, CheckDataState },
                { 8, CheckDataType },
                { 9, CheckDataLength },
                { 10, CheckDataWidth },
                { 11, CheckDataHight }
        };

        private delegate bool CheckData(object obj);

        private static bool CheckDataHight(object obj)
        {
            int power = (int)obj;
            return hightStartNumericUpDown.Value < power && power < hightEndNumericUpDown.Value;
        }

        private static bool CheckDataWidth(object obj)
        {
            int power = (int)obj;
            return widthStartNumericUpDown.Value < power && power < widthEndNumericUpDown.Value;
        }

        private static bool CheckDataLength(object obj)
        {
            int power = (int)obj;
            return lengthStartNumericUpDown.Value < power && power < lengthEndNumericUpDown.Value;
        }

        private static bool CheckDataType(object obj)
        {
            string type = (string)obj;

            bool fl = false;
            bool fl2 = false;

            foreach (string str in typeСheckedListBox.CheckedItems)
            {
                fl |= str == type;
                fl2 = true;                
            }

            if (fl2)
            {
                if (fl)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private static bool CheckDataState(object obj)
        {
            string state = (string)obj;

            bool fl = false;
            bool fl2 = false;
           
            foreach (string str in stateСheckedListBox.CheckedItems)
            {
                fl |= str == state;
                fl2 = true;
            }

            if (fl2)
            {
                if (fl)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private static bool CheckDataNumberEngines(object obj)
        {
            int power = (int)obj;
            return numberEnginesStartNumericUpDown.Value < power && power < numberEnginesEndNumericUpDown.Value;
        }

        private static bool CheckDataMass(object obj)
        {
            int power = (int)obj;
            return massStartNumericUpDown.Value < power && power < massEndNumericUpDown.Value;
        }

        private static bool CheckDataPerformance(object obj)
        {
            int power = (int)obj;
            return performanceStartNumericUpDown.Value < power && power < performancEndNumericUpDown.Value;
        }

        private static bool CheckDataMaxSize(object obj)
        {
            int power = (int)obj;
            return maxSizeStartNumericUpDown.Value < power && power < maxSizeEndNumericUpDown.Value;
        }

        private static bool CheckDataPower(object obj)
        {
            int power = (int)obj;
            return powerStartNumericUpDown.Value < power && power < powerEndNumericUpDown.Value;
        }

        private static bool CheckDataCoast(object obj)
        {
            int coast = (int)obj;
            return coastStartNumericUpDown.Value < coast && coast < coastEndNumericUpDown.Value;
        }
    }
}
