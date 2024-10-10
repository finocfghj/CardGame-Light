using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 角色信息
/// </summary>
public class PlayerManager
{
    public static PlayerManager Instance = new PlayerManager();

    // 存储角色拥有的卡牌的id、名字、或者其他什么的
    public List<string> cardList;

    // 角色的其他信息

    // 初始化角色拥有的卡牌
    public void Init()
    {
        cardList = new List<string>();
        
        // 添加卡牌
        // cardList.Add(...);
    }
}
