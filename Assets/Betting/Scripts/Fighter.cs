using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter
{
    string name;
    string reach;
    string height;
    string fighterType;
    string imageFileName;
    string index;
    readonly string UNKNOWN = "UNKNOWN";
    readonly string UNKNOWN_NUMBER = "99";
    readonly string UNKNOWN_IMAGE_FILENAME = "Unknown-human-picture.png";

    public Fighter(string name,string reach,string height, string fighterType, string imageFileName, string index)
    {
        this.name = name;
        this.reach = reach;
        this.height = height;
        this.fighterType = fighterType;
        this.imageFileName = imageFileName;
        this.index = index;

    }

    public Fighter()
    {
        this.imageFileName = UNKNOWN_IMAGE_FILENAME;
        this.index = "0";
        this.name = UNKNOWN;
        this.reach = UNKNOWN_NUMBER;
        this.height = UNKNOWN_NUMBER;
        this.fighterType = UNKNOWN;
    }

    public string GetFighterName()
    {
        return this.name;
    }

    public string GetFighterReach()
    {
        return this.reach;
    }

    public string GetFighterHeight()
    {
        return this.height;
    }

    public string GetFighterType()
    {
        return this.fighterType;
    }

    public string GetImageFileName()
    {
        return this.imageFileName;
    }

    public string GetIndex()
    {
        return this.index;
    }

    public override string ToString()
    {
        return "Index: "+this.index+": "+this.name + " is this tall:" + this.height + ", has this reach:" + this.reach + ",and is of type:" + this.fighterType;
    }
}
