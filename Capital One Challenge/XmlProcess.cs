/*********************************************************************
 * 
 *      Capital One Mindo Sumo Challenge
 *      
 *      File:   XmlProcess.cs
 *      Author: Kevin Matesi
 *      Date:   11/26/2014
 *      
 *      This file contains the XmlProcess class defintion. This class
 *      will be responsible for querying the SportsData Standings API,
 *      and producing an xml string that can be deserialized into a
 *      Standings object.
 *       
*********************************************************************/

using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Text;

namespace CapitalOne
{
    /// <summary>
    /// Class that will be used to send HTTP Requests, and retrieve data in an xml format.
    /// </summary>
    /// <remarks>
    /// This is class provides the capacity to issue an HTTP GET request to the SportsData Standings API
    /// and retrieve an xml output. In addition, this class can work with the Standings class to deserialize
    /// the xml into a Standings heiarchical object.
    /// </remarks>
    public class XmlProcess
    {
        /// <summary>
        /// This is the schema layout for the Standins API.
        /// </summary>
        /// <remarks>
        /// This will be used when deserializing the xml into a Standings object. This reference should not change
        /// which is why it is defined as a constant.
        /// </remarks>
        const string SCHEMA = "http://feed.elasticstats.com/schema/ncaafb/standings-v1.0.xsd";

        /// <summary>
        /// This is the key that will be needed to gain access to the requested data.
        /// </summary>
        /// <remarks>
        /// This is set a a readonly property. When a XmlProcess object is defined, this
        /// will need to be supplied to the constructor, if a different key than the one
        /// provided for the mind sumo challenge.
        /// </remarks>
        readonly string KEY;

        /// <summary>
        /// This is the access level used in the HTTP request.
        /// </summary>
        /// <remarks>
        /// This is set a a readonly property. When a XmlProcess object is defined, this
        /// will need to be supplied to the constructor, if a different access level than 
        /// the one provided for the mind sumo challenge.
        /// </remarks>
        readonly string ACCESSLVL;

        /// <summary>
        /// This is the version number that is associated with the access level
        /// for an HTTP request.
        /// </summary>
        /// <remarks>
        /// This is set a a readonly property. When a XmlProcess object is defined, this
        /// will need to be supplied to the constructor, if a different version number 
        /// than the one provided for the mind sumo challenge.
        /// </remarks>
        readonly string VERSION;

        /// <summary>
        /// Default constructor that sets readonly properties for HTTP requests.
        /// </summary>
        /// <remarks>
        /// The default constructor will set the readonly properties to the 
        /// given values for the mind sumo challenge
        /// </remarks>
        public XmlProcess()
        {
            KEY = "x9bnj5h4kpaqzp89eers23p9";   // set key
            ACCESSLVL = "t";                    // set access level
            VERSION = "1";                      // set version
        }//endctor

        /// <summary>
        /// Overload constructor that sets the readonly properties for the HTTP requests.
        /// </summary>
        /// <param name="K">Key value to use for HTTP Request</param>
        /// <param name="A">Access level value to use for HTTP Request</param>
        /// <param name="V">Version value to use for HTTP Request</param>
        public XmlProcess(string K, string A, string V)
        {
            KEY = K;            // set key
            ACCESSLVL = A;      // set access level
            VERSION = V;        // set version
        }//endctor

        /// <summary>
        /// Property for the API Key.
        /// </summary>
        /// <remarks>
        /// This is mainly for debugging purposes.
        /// </remarks>
        public string Key
        {
            get { return KEY; } // return the key value
        }

        /// <summary>
        /// Method to send HTTP request to Standings API and retrieve xml string.
        /// </summary>
        /// <remarks>
        /// This method can only be used to query the Standings API. It will first
        /// build the string for the HTTP request, and then use the a WebRequest and
        /// WebResponse object to query and retrieve the data.
        /// </remarks>
        /// <param name="division">The division for the conference and teams you want (eg. FBS or FCS)</param>
        /// <param name="year">The year of the data that you are trying to retrieve</param>
        /// <param name="season">The part of the season for the data (eg. REG for regular season)</param>
        /// <returns>The querired data in xml format, or null if there was an error in the request</returns>
        public string GetXmlResponse(string division, string year, string season)
        {
            /***************************************/
            /***** START BUILDING HTTP REQUEST *****/
            StringBuilder request = new StringBuilder();
            request.Append("http://api.sportsdatallc.org/ncaafb-");
            request.Append(ACCESSLVL + VERSION + "/teams/");
            request.Append(division + "/");
            request.Append(year + "/");
            request.Append("standings.xml?api_key=");
            request.Append(KEY);
            /****** END BUILDING HTTP REQUEST ******/
            /***************************************/

            try     // try to send the http request
            {
                Console.Write("Sending HTTP GET Request, waiting for reply...");

                WebRequest httpreq = WebRequest.Create(request.ToString()); // build the request
                httpreq.ContentType = "application/xml; charset=utf-8";     // set the request content type
                WebResponse response = httpreq.GetResponse();               // send the request, and get the response

                Stream ds = response.GetResponseStream();                   // get the xml stream from the response
                StreamReader rdr = new StreamReader(ds);                    // create a stream reader to process the stream

                Console.WriteLine("Success!\n");
                return rdr.ReadToEnd();                                     // use the reader to return a single long string of xml formatted data
            }//endtry
            catch (WebException e)              // catch any web exceptions
            {
                Console.WriteLine(e.Message);   // output the error message
                return null;                    // return a null string
            }//endcatch
        }//endmethod

        /// <summary>
        /// Deserialize standings xml data into Standings object.
        /// </summary>
        /// <remarks>
        /// This method will make use of the Standings class, and all
        /// subsequent classes to deserialize the Standings xml data. It
        /// will use the schema from the SportsData site to deserialize the
        /// data into the Standings object.
        /// </remarks>
        /// <param name="xml">the xml string to deserialize into a Standings object</param>
        /// <returns>A standings object with all the associated conferences and teams, or null if it fails</returns>
        public Standings deserializeXml(String xml)
        {
            Standings s = new Standings();      // create a new Standings object to return to the caller
            try                                 // try to deserialize the standings object
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Standings), SCHEMA);    // use the Xml class to serialization object referencing associated schema

                XmlReader x = XmlReader.Create(new StringReader(xml));                      // use an xml reader object to process and mark the xml
                s = (Standings)serializer.Deserialize(x);                                   // deserialize the standings object

                return s;                       // return the newly build standings object
            }//endtry
            catch (InvalidOperationException e) // catch any xml errors in deserializing
            {
                Console.WriteLine(e.Message);   // print out message to user
                return null;                    // return a null object because it failed
            }//endcatch
        }//endmethod
    }//endclass
}
