using StreetlightDistribution.Logic.Interfaces;
using StreetlightDistribution.Model.DTO;

namespace StreetlightDistribution.Logic
{
    public class StreetlightDistributor : IStreetlightDistributor
    {
        public StreetlightResponse DistributeStreetlights(StreetlightRequest request)
        {
            var plots = request.Neighbourhood;
            var result = new List<List<string>>();

            for (int i = 0; i < plots.Count; i++)
            {
                if (i % 2 != 0 && !plots[i - 1].Any(x => x == "P"))
                {
                    var roadRow = new List<string>();
                    for (int j = 0; j < plots[i].Count; j++)
                    {
                        roadRow.Add("N");
                    }
                    result.Add(roadRow);
                }
                else
                {
                    var rowResult = PlaceLightsPlots(plots[i]);
                    result.Add(rowResult);
                   
                }
            }

            return new StreetlightResponse { Plots = result };
        }
        private List<string> PlaceLightsPlots(List<string> row)
        {
            var rowResult = new List<string>();
            bool rowsBeforePark = row.Any(x => x.Equals("P"));
            for (int j = 0; j < row.Count; j++)
            {

                if (rowsBeforePark)
                {
                    rowResult.Add("N");
                    rowsBeforePark = row[j] == "P" ? false : true;
                }
                else
                {
                    if (j > 0 && row[j - 1] != "P")
                    {
                        rowResult.Add("R");
                    }
                    else
                    {
                        rowResult.Add("B");
                    }
                }
            }
            return rowResult;
        }
    }
}
