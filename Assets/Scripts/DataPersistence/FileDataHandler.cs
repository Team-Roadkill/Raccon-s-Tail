/////////////////////////////////////////////////////////
/// Creator : Chris Johnson
/// Date Created : 29/01/2023
/// Purpose : handles how to save and load data from/to the save file
/////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string sDataDirPath = ""; //path to save to
    private string sDataFileName = ""; //file name to use

    private bool bUseEncryption = false; //should encryption be used
    private readonly string ro_sEncryptionCodeWord = "Racoon"; //word used to cross encrpt

    /// <summary>
    /// constructor for a new file data handler
    /// </summary>
    /// <param data path to store save="a_sDataDirPath"></param>
    /// <param name of file created="a_sDataFileName"></param>
    /// <param should encrption be used="a_sUseEncrypton"></param>
    public FileDataHandler(string a_sDataDirPath, string a_sDataFileName, bool a_sUseEncrypton)
    {
        sDataDirPath = a_sDataDirPath;
        sDataFileName = a_sDataFileName;
        bUseEncryption = a_sUseEncrypton;
    }

    /// <summary>
    /// load data from save file
    /// </summary>
    public GameData Load()
    {
        //path combine for more adaptability
        string fullPath = Path.Combine(sDataDirPath, sDataFileName); //get the full path to save to
        GameData loadedData = null; 
        if (File.Exists(fullPath))
        {
            try
            {
                //load the serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open)) //open stream to read from file
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd(); //read while file
                    }
                }

                //decrypt if enabled
                if (bUseEncryption == true)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad); //decrypt data
                }

                //deserialize data 
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);

            }
            catch (Exception e)
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e); //output error
            }
        }
        return loadedData; 
    }

    public void Save(GameData a_gdData)
    {
        //path combine for more adaptability
        string fullPath = Path.Combine(sDataDirPath, sDataFileName); //get the full path to save to

        try
        {
            //create the directory the file will be written to if it doesnt already exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //serialize the c# game data object into json
            string sDataToStore = JsonUtility.ToJson(a_gdData, true);

            //encrypt if enabled
            if (bUseEncryption == true)
            {
                sDataToStore = EncryptDecrypt(sDataToStore);
            }

            //using ensures connection is close after
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) //write the serialized data to the file
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(sDataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error occured when trying to save data to file: " + fullPath + "\n" + e); //output error
        }
    }

    /// <summary>
    /// //XOR operation between the data and the codeword
    /// </summary>
    /// <param data the encrypt="sData"></param>
    /// <returns>encrypted data</returns>
    private string EncryptDecrypt(string sData)
    {
        string modifiedData = "";
        //loop though data
        for (int i = 0; i < sData.Length; i++)
        {
            modifiedData += (char)(sData[i] ^ ro_sEncryptionCodeWord[i % ro_sEncryptionCodeWord.Length]); //encrpt / decrypt
        }
        return modifiedData;
    }
}
