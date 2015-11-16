//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Xml;

using UnityEngine;

public class Eventlogger : MonoBehaviour
{
	private static Eventlogger instance = null;
	private bool levelOpend = false;
	private XmlWriter writer;
	public XmlWriter Writer{
		get{ return writer;}
	}

    void Awake()
    {
        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
        xmlWriterSettings.NewLineOnAttributes = true;
        xmlWriterSettings.Indent = true;
        writer = XmlWriter.Create(DateTime.Now.Ticks + "_Mehruhn_log.xml", xmlWriterSettings);
        writer.WriteStartDocument();

        GameObject.DontDestroyOnLoad(gameObject);
    }

	void OnDestroy ()
	{
		EndLevel ();
		writer.WriteEndDocument();
		writer.Close();
	}

	public static Eventlogger getInstance(){
		if(instance == null){
            var go = new GameObject("Logger");
			instance = go.AddComponent<Eventlogger>();
		}
		return instance;
	}

	public void StartEvent(String eventType){
		writer.WriteStartElement(eventType);
        writer.WriteElementString("levelTime", Time.time.ToString());
	}

	public void EndEvent(){
		writer.WriteEndElement();
	}

	public void WritePositon(Vector3 pos){
		writer.WriteStartElement("Position");
			writer.WriteElementString("x", pos.x.ToString());
	        writer.WriteElementString("y", pos.y.ToString());
	        writer.WriteElementString("z", pos.z.ToString());
		writer.WriteEndElement();
	}

	public void BeginLevel(String name){
		writer.WriteStartElement("Level");
		writer.WriteAttributeString ("name", name);
		levelOpend = true;
	}

	public void EndLevel(){
		if (levelOpend) {
			levelOpend = false;
			writer.WriteEndElement ();
		}
	}
}

