using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 책 내용을 미리 등록한 후, 책의 정보를 이용하여 책을 검색하는 도서검색 서비스
/// 1. 5권 정도의 도서를 등록
/// 2. Library라는 이름의 딕셔너리에 책을 넣는다
/// </summary>

public class DictionaryStudy : MonoBehaviour
{
    [Header("검색 페이지")]
    public GameObject searchPanel;
    public GameObject registerPanel;
    public Button searchBtn;
    public TMP_Dropdown dropdown;
    public TMP_Text logSearch;
    public InputField inputSearch;

    [Space(20)]
    [Header("등록 페이지")]

    public InputField inputBookname; 
    public InputField inputLocation;
    public TMP_Text logRegister;
    public Button registerBtn;
    

    Dictionary<string, string> library = new Dictionary<string, string>();

    


    void Start()
    {
        library.Add("Lee", "1,1");
        library.Add("Lee1", "2,3");
        library.Add("Lee2", "1,3");
        library.Add("Lee3", "1,2");
        library.Add("Lee4", "1,4");

        logSearch.text =$"Please enter the name of the book";
        logRegister.text =$"Please enter the name and the location of the book";
    }

   
    // 실습 1.
    // 1. 도서 등록 : 책 제목 또는 위치를 입력받아 도서 등록
    
    public void RegisterBtnClk()
    {
        string bookname = inputBookname.text;
        string location = inputLocation.text;

        if(bookname == "" || location =="")
        {
            logRegister.text = $"Enter the name and the location of the book.";

            return;
        }
        string value = inputBookname.text;
        string value2 = inputLocation.text;

        library.Add(value, value2);
        logRegister.text = $"{value} is registered on {location}";

        // dropdown.itemText
        // input.Text 정보 기반 책 등록
        // library.Add

    }
    // 2. 도서 검색 : 책 제목 또는 위치를 입력받아 결과를 출력
    public void SearchBtnClk()
    {
        logSearch.text = "";
        string bookname = "";
        string location = "";

        switch (dropdown.value)
        {
            case 0:
                bookname = inputSearch.text;

                if(bookname =="")
                {
                    logSearch.text = $"Please enter the name of the book.";
                    return;
                }
                if(library.ContainsKey(bookname))
                {
                    location = library[bookname];
                    logSearch.text = $"{bookname} is located on {location}";
                }
                else
                {
                    logSearch.text = $"No books on the list";
                }
                break;

            case 1:
                location = inputSearch.text;

                if (location == "")
                {
                    logSearch.text = $"Please enter the location of the book.";
                    return;
                }
                if (library.ContainsValue(location))
                {
                    string key = library.FirstOrDefault(x => x.Value == location).Key;
                    logSearch.text += $"{key} is located on {location}.";
                }
                else
                    logSearch.text += $"No books";
                break;
        }
    }

    public void MoveNextPage(bool isSearchPage)
    {
        searchPanel.SetActive(!isSearchPage);
        registerPanel.SetActive(isSearchPage);
    }
    
    public void ShowListBtn()
    {
        logSearch.text = "";
        logRegister.text = "";

        if (searchPanel.activeSelf)
        {
            foreach (KeyValuePair<string, string> bookInfo in library)
            {
                logSearch.text += $"{bookInfo.Key} is on {bookInfo.Value}\n";
            }
        }
        else
        {
            foreach (KeyValuePair<string, string> bookInfo in library)
            {
                logRegister.text += $"{bookInfo.Key} is on {bookInfo.Value}\n";
            }
        }
    }
}
