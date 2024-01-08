 void SaveData()
    {
        _instance = this;
        string temp = "MapManager_" + MapType;
        ES3.Save<MapManager>(temp, _instance);
    }
    void LoadData()
    {
        string temp = "MapManager_" + MapType;
        if (ES3.KeyExists(temp) == true)
        {            
            
            _instance = ES3.Load<MapManager>(temp);
        }
    }