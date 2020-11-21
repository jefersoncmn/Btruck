using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/// <summary>
/// Classe responsável por percorrer pastas do jogo em busca do nome dos arquivos para cerregalos em game
/// </summary>
public static class FileName
{

    /// <summary>
    /// Ter acesso a uma lista dos nomes dos arquivos no diretorio específico para, posteriormente carrega-los
    /// </summary>
    /// <param name="path">Caminho do arquivo/Diretorio</param>
    /// <param name="extension">A extensao do tipo de arquivo, ex: .prefab</param>
    /// <returns></returns>
    public static List<string> GetFilesNames(string path, string extension){
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] infos = dir.GetFiles("*"+extension);//array "infos" todos os arquivos do diretório

        List<string> names = new List<string>();

        foreach(FileInfo file in infos){
            var name = file.Name.ToString();
            name = name.Replace(extension, "");
            names.Add(name);
        }
        return names;
    }
}
