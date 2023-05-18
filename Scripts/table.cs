using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using models.dto;
using models.inputs;
using models.inputs.QueryHelper;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Person : Row
{
    public string name { get; set; }
    public int age { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}

public class Save
{
    [JsonProperty("userid")]
    public string UserId { get; set; }
    [JsonProperty("username")]
    public string UserName { get; set; }
}

public class table : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public Button BackButton;
    [SerializeField] public Button FindRowsButton;
    [SerializeField] public Button FindRowByIdButton;
    [SerializeField] public Button InsertButton;
    [SerializeField] public Button EditButton;
    [SerializeField] public Button DeleteButton;
    [SerializeField] public TMP_InputField TableIdParams;
    [SerializeField] public TMP_InputField RowIdParams;

    void Start()
    {
        BackButton.onClick.AddListener(async () => { SceneManager.LoadScene("mainMenu"); });

        FindRowsButton.onClick.AddListener(async () =>
        {
            var tableId = TableIdParams.text;
            var rows = await DynamicPixels.Table.Find<Save, FindParams>(new FindParams
            {
                tableId = tableId,
                options = new FindOptions
                {
                    // Conditions = new Eq("name", "amir").ToQuery(),
                    // Joins = new List<JoinParams>(new []
                    // {
                    //     new JoinParams{TableName = "645c338daf12d097d14c5d23", foreignField = "id", localField = "name"}, 
                    // })
                }
            });

            Debug.Log(JsonConvert.SerializeObject(rows));
            foreach (var row in rows.List)
            {
                Debug.Log(row.ToString());
            }
        });

        FindRowByIdButton.onClick.AddListener(async () =>
        {
            var tableId = TableIdParams.text;
            var rowId = RowIdParams.text;

            var row = await DynamicPixels.Table.FindById<Person, FindByIdParams>(new FindByIdParams
            {
                RowId = Int32.Parse(rowId),
                TableId = tableId
            });
            
            Debug.Log(row);
        });

        InsertButton.onClick.AddListener(async () =>
        {
            var tableId = TableIdParams.text;

            
            var row = await DynamicPixels.Table.Insert<Person, InsertParams>(new InsertParams
            {
                TableId = tableId,
                Data = new Person
                {
                    name = "parya",
                    age = 18
                }
            });
        });

        EditButton.onClick.AddListener(async () =>
        {
            var tableId = TableIdParams.text;
            var rowId = RowIdParams.text;

            var row = await DynamicPixels.Table.FindByIdAndUpdate<Person, FindByIdAndUpdateParams>(new FindByIdAndUpdateParams
            {
                RowId = Int32.Parse(rowId),
                TableId = tableId,
                Data = new Person
                {
                    age = 100
                }
            });
        });

        DeleteButton.onClick.AddListener(async () =>
        {
            var tableId = TableIdParams.text;
            var rowId = RowIdParams.text;

            await DynamicPixels.Table.Delete(new DeleteParams
            {
                TableId = tableId,
                RowIds = new[] { Int32.Parse(rowId),}
            });
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
