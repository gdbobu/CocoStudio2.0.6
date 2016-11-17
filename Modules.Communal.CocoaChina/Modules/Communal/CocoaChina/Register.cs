// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocoaChina.Register
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using Jisons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modules.Communal.CocoaChina
{
    public class Register
    {
        public const string RegisterUrl = "http://open.cocoachina.com/api/user_reg";

        public static User RegisterCocoaChina(string name, string password, string email = "")
        {
            User user = new User
            {
                UserName = name,
                PassWord = password,
                Email = email
            };
            string responseOfString = "http://open.cocoachina.com/api/user_reg".GetResponseOfString("post", user.LoginData);
            if (responseOfString.Contains("status"))
            {
                if (responseOfString.Contains("error"))
                {
                    string text = responseOfString.Split(new string[]
					{
						"msg"
					}, StringSplitOptions.RemoveEmptyEntries).LastOrDefault<string>();
                    text = text.Replace("\\u", "&#x");
                    if (text.Contains("&#x6ce8&#x518c&#x5931&#x8d25,&#x7528&#x6237&#x540d&#x5df2&#x7ecf&#x5b58&#x5728"))
                    {
                    }
                }
            }
            return user;
        }
    }
}
