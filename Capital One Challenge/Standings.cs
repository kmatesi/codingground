/*********************************************************************
 * 
 *      Capital One Mindo Sumo Challenge
 *      
 *      File:   Standings.cs
 *      Author: Kevin Matesi
 *      Date:   11/26/2014
 *      
 *      This is the Standings class defintion. This class will be used
 *      to hold the deserialized xml data obtained via HTTP GET from
 *      the SportsData Standings API. Each level of the xml structure
 *      is reperesented by a different class to match the SportsData
 *      Standings schema which can be found at the following link:
 *      
 *      http://feed.elasticstats.com/schema/ncaafb/standings-v1.0.xsd
 *       
*********************************************************************/

using System;
using System.Net;
using System.Xml.Serialization;

namespace CapitalOne
{
    /// <summary>
    /// Standings class for the root level in the SportsData standings xml document.
    /// </summary>
    /// <remarks>
    /// This class will make use of three different tags to associate each property with
    /// its Xml object type. This class is the root of the xml document, where an element
    /// is subsequent class and an attribute is a value. Each xml object has get and set
    /// properties associated with it.
    /// </remarks>
    [XmlRoot("standings")]
    public class Standings
    {
        /// <summary>
        /// division object that will contain division, conferences, and teams data
        /// </summary>
        [XmlElement("division")]
        public Division Division { get; set; }

        /// <summary>
        /// year of seasons standings
        /// </summary>
        /// <value>2014</value>
        [XmlAttribute("season")]
        public string Season { get; set; }

        /// <summary>
        /// type of the season
        /// </summary>
        /// <value>REG</value>
        [XmlAttribute("type")]
        public string Type { get; set; }
    }//endclass

    /// <summary>
    /// class that holds all division related data, and an array of associated conferences
    /// </summary>
    /// <remarks>
    /// This class will make use of two different tags to associate each property with
    /// its Xml object type. An element is subsequent class and an attribute is a value. 
    /// Each xml object has get and set properties associated with it.
    /// </remarks>
    public class Division
    {
        /// <summary>
        /// An array of Conference objects that will contain related conference and team data
        /// </summary>
        [XmlElement("conference")]
        public Conference[] Conference { get; set; }

        /// <summary>
        /// unique id associated with the division
        /// </summary>
        /// <value>FBS</value>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// name of the division
        /// </summary>
        /// <value>I-A</value>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }//endclass

    /// <summary>
    /// class that holds all conference related data, and an array of associated teams
    /// </summary>
    /// <remarks>
    /// This class will make use of two different tags to associate each property with
    /// its Xml object type. An element is subsequent class and an attribute is a value. 
    /// Each xml object has get and set properties associated with it.
    /// </remarks>
    public class Conference
    {
        /// <summary>
        /// an array of Team objects that contain team related data (eg. wins and losses)
        /// </summary>
        [XmlElement("team")]
        public Team[] Team { get; set; }

        /// <summary>
        /// unique id associated with the conference
        /// </summary>
        /// <value>ACC</value>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// name of the conference
        /// </summary>
        /// <value>ACC</value>
        [XmlAttribute("name")]
        public string Name { get; set; }
    }//endclass

    /// <summary>
    /// class that holds all division related data, and an array of associated conferences
    /// </summary>
    /// <remarks>
    /// This class will make use of two different tags to associate each property with
    /// its Xml object type. An element is subsequent class and an attribute is a value. 
    /// Each xml object has get and set properties associated with it.
    /// 
    /// In addition, the &lt;,&lt;=,&gt;,&gt;= operators are overloaded to allow for comparing of
    /// Team objects. This will be used in the quick sort method.
    /// </remarks>
    public class Team
    {
        /// <summary>
        /// unique id associated to a team
        /// </summary>
        /// <value>FSU</value>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// name of a team
        /// </summary>
        /// <value>Seminoles</value>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// institution associated with the team
        /// </summary>
        /// <value>Florida State</value>
        [XmlAttribute("market")]
        public string Market { get; set; }

        /// <summary>
        /// subdivision for the team
        /// </summary>
        /// <value>ACC-ATLANTIC</value>
        [XmlAttribute("subdivision")]
        public string Subdivision { get; set; }

        /// <summary>
        /// overall record stats
        /// </summary>
        [XmlElement("overall")]
        public Overall Overall { get; set; }

        /// <summary>
        /// in conference record stats
        /// </summary>
        [XmlElement("in_conference")]
        public In_Conference In_Conference { get; set; }

        /// <summary>
        /// non conference record stats
        /// </summary>
        [XmlElement("non_conference")]
        public Non_Conference Non_Conference { get; set; }

        /// <summary>
        /// in division record stats
        /// </summary>
        [XmlElement("in_division")]
        public In_Division In_Division { get; set; }

        /// <summary>
        /// home record stats
        /// </summary>
        [XmlElement("home")]
        public Home Home { get; set; }

        /// <summary>
        /// away record stats
        /// </summary>
        [XmlElement("away")]
        public Away Away { get; set; }

        /// <summary>
        /// overtime record stats
        /// </summary>
        [XmlElement("overtime")]
        public Overtime Overtime { get; set; }

        /// <summary>
        /// record stats playing on grass
        /// </summary>
        [XmlElement("grass")]
        public Grass Grass { get; set; }

        /// <summary>
        /// record stats playing on turf
        /// </summary>
        [XmlElement("turf")]
        public Turf turf { get; set; }

        /// <summary>
        /// record stats on games won by at least 7 points
        /// </summary>
        [XmlElement("decided_by_7_points")]
        public By_7_Points By_7_Points { get; set; }

        /// <summary>
        /// record stats when leadin at half
        /// </summary>
        [XmlElement("leading_at_half")]
        public Leading_At_Half Leading_At_Half { get; set; }

        /// <summary>
        /// record stats of last 5 games
        /// </summary>
        [XmlElement("last_5")]
        public Last_5 Last_5 { get; set; }

        /// <summary>
        /// points the team has allowed and scored
        /// </summary>
        [XmlElement("points")]
        public Points Points { get; set; }

        /// <summary>
        /// touchdowns the team has allowed and scored
        /// </summary>
        [XmlElement("touchdowns")]
        public Touchdowns Touchdowns { get; set; }

        /// <summary>
        /// current streak the team is on
        /// </summary>
        [XmlElement("streak")]
        public Streak Streak { get; set; }

        /// <summary>
        /// Compares two Team objects to see if the left operand is greater than the right operand
        /// </summary>
        /// <remarks>
        /// A Team object is greater if it belongs higher in a list in descending order. The 
        /// comparison will check the following variables for each object. If the two have
        /// equivalent values, then it will move on to the next variable to check. If they are
        /// still equal after the last comparison, it is considered to be less than. Check 
        /// winning percentage, wins, net points, alphabetical order, in that order.
        /// </remarks>
        /// <param name="t1">left operand</param>
        /// <param name="t2">right operand</param>
        /// <returns>true if t1 is greater than t2, else false</returns>
        public static bool operator >(Team t1, Team t2)
        {
            if (t1.Overall.Wpct > t2.Overall.Wpct)          // check winning percentage
                return true;
            else if (t1.Overall.Wpct < t2.Overall.Wpct)     // check to make sure it is not less
                return false;
            else                                            // must be equal, check wins
            {
                if (t1.Overall.Wins > t2.Overall.Wins)      // check wins
                    return true;
                else if (t1.Overall.Wins < t2.Overall.Wins) // check to make sure it is not less
                    return false;
                else                                        // must be euqal, check net points
                {
                    if (t1.Points.Net > t2.Points.Net)      // check net points
                        return true;
                    else if (t1.Points.Net < t2.Points.Net) // check to make sure it is not less
                        return false;
                    else                                    // must be equal
                    {
                        if (t1.Name.CompareTo(t2.Name) < 0) // check alphabetical order
                            return true;
                        else                                // either equal or less than
                            return false;
                    }//endelse
                }//endelse
            }//endelse
        }//endmethod

        /// <summary>
        /// Compares two Team objects to see if the left operand is greater than or 
        /// equal to the right operand
        /// </summary>
        /// <remarks>
        /// A Team object is greater or equal if it belongs higher in a list in descending order. The 
        /// comparison will check the following variables for each object. If the two have
        /// equivalent values, then it will move on to the next variable to check. If they are
        /// still equal after the last comparison, it is considered to be greater than. Check 
        /// winning percentage, wins, net points, alphabetical order, in that order.
        /// </remarks>
        /// <param name="t1">left operand</param>
        /// <param name="t2">right operand</param>
        /// <returns>true if t1 is greater than or equal to t2, else false</returns>
        public static bool operator >=(Team t1, Team t2)
        {
            if (t1.Overall.Wpct > t2.Overall.Wpct)          // check winning percentage
                return true;
            else if (t1.Overall.Wpct < t2.Overall.Wpct)     // check to make sure it is not less
                return false;
            else                                            // must be equal, check wins
            {
                if (t1.Overall.Wins > t2.Overall.Wins)      // check wins
                    return true;
                else if (t1.Overall.Wins < t2.Overall.Wins) // check to make sure it is not less
                    return false;
                else                                        // must be euqal, check net points
                {
                    if (t1.Points.Net > t2.Points.Net)      // check net points
                        return true;
                    else if (t1.Points.Net < t2.Points.Net) // check to make sure it is not less
                        return false;
                    else                                    // must be equal
                    {
                        if (t1.Name.CompareTo(t2.Name) <= 0)// check alphabetical order
                            return true;
                        else                                // must be less than
                            return false;
                    }//endelse
                }//endelse
            }//endelse
        }//endmethod

        /// <summary>
        /// Compares two Team objects to see if the left operand is less than the right operand
        /// </summary>
        /// <remarks>
        /// A Team object is less than if it belongs lower in a list in descending order. The 
        /// comparison will check the following variables for each object. If the two have
        /// equivalent values, then it will move on to the next variable to check. If they are
        /// still equal after the last comparison, it is considered to be greater than. Check 
        /// winning percentage, wins, net points, alphabetical order, in that order.
        /// </remarks>
        /// <param name="t1">left operand</param>
        /// <param name="t2">right operand</param>
        /// <returns>true if t1 is less than t2, else false</returns>
        public static bool operator <(Team t1, Team t2)
        {
            if (t1.Overall.Wpct < t2.Overall.Wpct)          // check winning percentage
                return true;
            else if (t1.Overall.Wpct > t2.Overall.Wpct)     // check to make sure it is not greater
                return false;
            else                                            // must be equal, check wins
            {
                if (t1.Overall.Wins < t2.Overall.Wins)      // check wins
                    return true;
                else if (t1.Overall.Wins > t2.Overall.Wins) // check to make sure it is not greater
                    return false;
                else                                        // must be euqal, check net points
                {
                    if (t1.Points.Net < t2.Points.Net)      // check net points
                        return true;
                    else if (t1.Points.Net > t2.Points.Net) // check to make sure it is not greater
                        return false;
                    else                                    // must be equal
                    {
                        if (t1.Name.CompareTo(t2.Name) > 0) // check alphabetical order
                            return true;
                        else                                // either equal or greater than
                            return false;
                    }//endelse
                }//endelse
            }//endelse
        }//endmethod

        /// <summary>
        /// Compares two Team objects to see if the left operand is less than or 
        /// equal to the right operand
        /// </summary>
        /// <remarks>
        /// A Team object is less than or equal to if it belongs lower in a list in descending 
        /// order. The comparison will check the following variables for each object. If the two have
        /// equivalent values, then it will move on to the next variable to check. If they are
        /// still equal after the last comparison, it is considered to be less than. Check 
        /// winning percentage, wins, net points, alphabetical order, in that order.
        /// </remarks>
        /// <param name="t1">left operand</param>
        /// <param name="t2">right operand</param>
        /// <returns>true if t1 is less than t2, else false</returns>
        public static bool operator <=(Team t1, Team t2)
        {
            if (t1.Overall.Wpct < t2.Overall.Wpct)          // check winning percentage
                return true;
            else if (t1.Overall.Wpct > t2.Overall.Wpct)     // check to make sure it is not greater
                return false;
            else                                            // must be equal, check wins
            {
                if (t1.Overall.Wins < t2.Overall.Wins)      // check wins
                    return true;
                else if (t1.Overall.Wins > t2.Overall.Wins) // check to make sure it is not greater
                    return false;
                else                                        // must be euqal, check net points
                {
                    if (t1.Points.Net < t2.Points.Net)      // check net points
                        return true;
                    else if (t1.Points.Net > t2.Points.Net) // check to make sure it is not greater
                        return false;
                    else                                    // must be equal
                    {
                        if (t1.Name.CompareTo(t2.Name) >= 0)// check alphabetical order
                            return true;
                        else                                // either greater than
                            return false;
                    }//endelse
                }//endelse
            }//endelse
        }//endmethod
    }//endclass

    /// <summary>
    /// class that holds overall record stats
    /// </summary>
    public class Overall
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class to hold in conference record data
    /// </summary>
    public class In_Conference
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class for non conference record data
    /// </summary>
    public class Non_Conference
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class that holds in division record data
    /// </summary>
    public class In_Division
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class that holds home record data
    /// </summary>
    public class Home
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class that holds away record data
    /// </summary>
    public class Away
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class that contains overtime record data
    /// </summary>
    public class Overtime
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class that contains record data playing on grass
    /// </summary>
    public class Grass
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class that holds record data when playing on turf
    /// </summary>
    public class Turf
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }

        /// <summary>
        /// winning percentage
        /// </summary>
        /// <value>0.875</value>
        [XmlAttribute("wpct")]
        public float Wpct { get; set; }
    }//endclass

    /// <summary>
    /// class that holds record data when up by 7 points
    /// </summary>
    public class By_7_Points
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }
    }//endclass

    /// <summary>
    /// class that holds record data when leading at half
    /// </summary>
    public class Leading_At_Half
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }
    }//endclass

    /// <summary>
    /// class that holds record data for the last five games
    /// </summary>
    public class Last_5
    {
        /// <summary>
        /// number of wins
        /// </summary>
        /// <value>11</value>
        [XmlAttribute("wins")]
        public int Wins { get; set; }

        /// <summary>
        /// number of losses
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("losses")]
        public int Losses { get; set; }

        /// <summary>
        /// number of ties
        /// </summary>
        /// <value>0</value>
        [XmlAttribute("ties")]
        public int Ties { get; set; }
    }//endclass

    /// <summary>
    /// class that holds points data for a team
    /// </summary>
    public class Points
    {
        /// <summary>
        /// points scored
        /// </summary>
        /// <value>854</value>
        [XmlAttribute("for")]
        public string For { get; set; }

        /// <summary>
        /// points given up
        /// </summary>
        /// <value>654</value>
        [XmlAttribute("against")]
        public string Against { get; set; }

        /// <summary>
        /// difference between points for and points against
        /// </summary>
        /// <value>200</value>
        [XmlAttribute("net")]
        public int Net { get; set; }
    }//endclass

    /// <summary>
    /// class that holds touchdown data for a team
    /// </summary>
    public class Touchdowns
    {
        /// <summary>
        /// touchdowns the team has scored
        /// </summary>
        /// <value>47</value>
        [XmlAttribute("for")]
        public int For { get; set; }

        /// <summary>
        /// touchdowns the team has given up
        /// </summary>
        /// <value>30</value>
        [XmlAttribute("against")]
        public int Against { get; set; }
    }//endclass

    /// <summary>
    /// class that holds data related to a teams current streak
    /// </summary>
    public class Streak
    {
        /// <summary>
        /// The type of streak either win, or loss
        /// </summary>
        /// <value>loss</value>
        [XmlAttribute("Type")]
        public string Type { get; set; }

        /// <summary>
        /// the number of games associated with the type of streak
        /// </summary>
        /// <value>4</value>
        [XmlAttribute("value")]
        public int Value { get; set; }
    }
}
