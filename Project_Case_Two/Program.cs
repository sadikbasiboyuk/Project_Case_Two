using Project_Case_Two;
using System.Text;
using System.Text.Json;

string jsonContent = File.ReadAllText("response.json");
var dataModelList = JsonSerializer.Deserialize<List<DataModel>>(jsonContent);
var sb = new StringBuilder();

// First element is ignored bec. of its locale
var minY = dataModelList[1].boundingPoly.vertices.Min(k => k.y);
var maxY = dataModelList[1].boundingPoly.vertices.Max(k => k.y);

var billList = new List<List<DataModel>>
{
    new List<DataModel>() { dataModelList[1] }
};

for (int i = 2; i < dataModelList.Count; i++)
{
    bool added = false;
    foreach (var bill in billList)
    {
        if (bill[0].boundingPoly.vertices.Average(x => x.y) > dataModelList[i].boundingPoly.vertices.Min(x => x.y)
            && bill[0].boundingPoly.vertices.Average(x => x.y) < dataModelList[i].boundingPoly.vertices.Max(x => x.y)
            )
        {
            bill.Add(dataModelList[i]);
            added = true;
            break;
        }
    }

    if (!added)
        billList.Add(new List<DataModel> { dataModelList[i] });

    added = false;
}

foreach (var row in billList)
{
    foreach (var element in row)
        sb.Append(element.description + ' ');

    sb.Append('\n');
}

Console.WriteLine(sb.ToString());