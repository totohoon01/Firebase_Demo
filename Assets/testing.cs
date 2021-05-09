using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;

public class testing : MonoBehaviour
{
    //데이터 세팅
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
        //데이터 베이스의 루트 주소
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
