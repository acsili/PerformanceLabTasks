using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;

internal class Program
{
    static void FillReport(Test test, Values value)
    {
        for (int i = 0; i < test.values.Length; i++)
        {
            for (int j = 0; j < value.values.Length; j++)
            {
                if (test.values[i].value is not null && test.values[i].id == value.values[j].id)
                {
                    test.values[i].value = value.values[j].value;
                }
            }
            if (test.values[i].values is not null)
            {
                FillReport(test.values[i], value);
            }
        }
        return;
    }



    static void Main(string[] args)
    {

        var jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var test = new Tests();
        var value = new Values();


        using (FileStream fs = new FileStream(args[0], FileMode.OpenOrCreate))
        {
            test = JsonSerializer.Deserialize<Tests>(fs, jsonOptions);
        }

        using (FileStream fs = new FileStream(args[1], FileMode.OpenOrCreate))
        {
            value = JsonSerializer.Deserialize<Values>(fs, jsonOptions);
        }


        for (int i = 0; i < test.tests.Length; i++)
        {
            for (int j = 0; j < value.values.Length; j++)
            {
                if (test.tests[i].value is not null && test.tests[i].id == value.values[j].id)
                {
                    test.tests[i].value = value.values[j].value;
                }
            }
            if (test.tests[i].values is not null)
            {
                FillReport(test.tests[i], value);
            }
        }

        using (FileStream fs = new FileStream("report.json", FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize<Tests>(fs, test, jsonOptions);
        }
    }
}


class Tests
{
    public Test[] tests { get; set; }
    [JsonConstructor]
    public Tests(Test[] tests)
    {
        this.tests = tests;
    }
    public Tests()
    {

    }
}


class Test
{
    public int id { get; set; }
    public string title { get; set; }
    public string value { get; set; }
    public Test[] values { get; set; }
    [JsonConstructor]
    public Test(int id, string title, string value, Test[] values)
    {
        this.id = id;
        this.title = title;
        this.value = value;
        this.values = values;
    }
    public Test(int id, string title, string value)
    {
        this.id = id;
        this.title = title;
        this.value = value;
    }
    public Test(int id, string value)
    {
        this.id = id;
        this.value = value;
    }
    public Test()
    {

    }
}


class Values
{
    public Value[] values { get; set; }
    [JsonConstructor]
    public Values(Value[] values)
    {
        this.values = values;
    }
    public Values()
    {

    }
}

class Value
{
    public int id { get; set; }
    public string value { get; set; }
    [JsonConstructor]
    public Value(int id, string value)
    {
        this.id = id;
        this.value = value;
    }
    public Value(int id)
    {
        this.id = id;
    }
}


