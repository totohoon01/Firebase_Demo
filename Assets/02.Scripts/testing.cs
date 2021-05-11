using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class testing : MonoBehaviour
{
    //데이터 베이스의 루트 주소

    public class User
    {
        public string userName;
        public string message;
        public string createTime;
        public string userPos;


        public User(string userName, string message, string createTime, string userPos)
        {
            this.userName = userName;
            this.message = message;
            this.createTime = createTime;
            this.userPos = userPos;
        }
    }

    //파이어베이스 연결하고 -> 패키지 임포팅
    void Start()
    {
        //데이터 베이스의 주소(루트)
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        // //json 파일 생성
        string json = WriteNewUser("hoon2064", "Hello!", "2 days ago", "medici");
        // //루트 -> users -> id, id, id에 추가 아이디가 동일하면 값이 갱신됨.
        // reference.Child("users").Child("1").SetRawJsonValueAsync(json);
        // //일부 객체만 업데이트하기 -> 계층으로 접근해서 업데이트.
        // reference.Child("users").Child("0").Child("userName").SetValueAsync("sang");
        // //해쉬 키 생성
        // string key = reference.Child("users").Push().Key;

        //데이터 출력
        reference.Child("users").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                foreach (var data in snapshot.Children)
                {
                    print(data.Value);
                    IDictionary user = (IDictionary)data.Value;
                    print(user);
                    // print(user["userName"]);
                }
            }
        });
    }

    string WriteNewUser(string userName, string message, string createTime, string userPos)
    {
        User user = new User(userName, message, createTime, userPos);
        string json = JsonUtility.ToJson(user);
        return json;
    }
}
