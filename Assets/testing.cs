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
        public string userEmail;

        public User(string userName, string userEmail)
        {
            this.userName = userName;
            this.userEmail = userEmail;
        }
    }

    //파이어베이스 연결하고 -> 패키지 임포팅
    void Start()
    {
        //데이터 베이스의 주소(루트)
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        //json 파일 생성
        string json = WriteNewUser("0", "hoon2", "hello.com");
        //루트 -> users -> id, id, id에 추가 아이디가 동일하면 값이 갱신됨.
        reference.Child("users").Child("1").SetRawJsonValueAsync(json);

        //일부 객체만 업데이트하기 -> 계층으로 접근해서 업데이트.
        reference.Child("users").Child("0").Child("userName").SetValueAsync("sang");
    }

    string WriteNewUser(string userId, string userName, string userEmail)
    {
        User user = new User(userName, userEmail);
        string json = JsonUtility.ToJson(user);
        return json;
    }
}
