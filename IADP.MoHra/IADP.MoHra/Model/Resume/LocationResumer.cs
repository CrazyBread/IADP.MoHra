using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IADP.MoHra.Helpers;
using IADP.MoHra.Model.Fuzzy;
using IADP.MoHra.Model.Result;

namespace IADP.MoHra.Model.Resume
{
    /// <summary>
    /// Класс, определяющий работу лингвистического резюмирования пространственной классификации.
    /// </summary>
    class LocationResumer : SingleResumer
    {
        public override string GetResult()
        {
            if (_result == null)
                throw new ArgumentException("Нет результатов");
            var result = "<h1>Резюмирование пространственной кластеризации</h1>";
            result += "<p><em>Производится оценка комфортности расположения сотрудников по кабинетам в зависимости от их должности. Отношение \"старший\"-\"младший\" должно быть примерно 1:3.</em></p>";
            result += _GetResultForA5();
            return result;
        }

        private string _GetResultForA5()
        {
            var result = "<ul>";
            var clastResult = _result.GetResult();
            
            var scale = FuzzyScaleRepository.ForA5();

            var rooms = clastResult.Select(i => i.Key.RoomNumber).Distinct().OrderBy(i => i).ToList();
            foreach (var room in rooms)
            {
                var roomResults = clastResult.Where(i => i.Key.RoomNumber == room);
                var jCount = roomResults.Count(i => i.Value.Claster == 'J');
                var mCount = roomResults.Count(i => i.Value.Claster == 'M');
                var sCount = roomResults.Count(i => i.Value.Claster == 'S');
                var smCount = mCount != 0 ? (double)sCount / mCount : 0.0;
                var sjCount = jCount != 0 ? (double)sCount / jCount : 0.0;
                var mjCount = jCount != 0 ? (double)mCount / jCount : 0.0;

                var roomValue = smCount + sjCount + mjCount;
                var roomValueResult = "";

                var scaleValue = scale.GetAccessory((decimal)roomValue);

                if (scaleValue.Name == "P54")
                    roomValueResult = "крайне комфортная";
                else if (scaleValue.Name == "P53")
                    roomValueResult = "комфортная";
                else if (scaleValue.Name == "P52")
                    roomValueResult = "не комфортная";
                else if (scaleValue.Name == "P51")
                    roomValueResult = "крайне не комфортная";
                else throw new ArgumentException();

                result += $"<li><strong>Комната {room}</strong>. Заполненность кабинета: {roomValueResult} (степень истинности: {scaleValue.Value:0.00}).</li>";
            }

            result += "</ul>";
            return result;
        }
    }
}