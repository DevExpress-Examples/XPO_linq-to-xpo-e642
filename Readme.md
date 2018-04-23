# LINQ to XPO


<p><strong>Scenario</strong><br /><a href="https://documentation.devexpress.com/#XPO/CustomDocument1998">XPO</a> includes the<em> </em><a href="https://documentation.devexpress.com/#XPO/clsDevExpressXpoXPQuery%7eT%7etopic">XPQuery<T></a>  class tailored for constructing <a href="http://msdn.microsoft.com/en-us/library/vstudio/bb397926.aspx">LINQ</a> expressions against persistent objects. XPO to LINQ expressions are turned into pure database queries. That is, an expression is processed on the database server side, and only the requested objects or a scalar value are loaded onto the client<br /><br />This example illustrates several sample queries such as:<br />- Group Join<br />- Select with Where and OrderBy clauses<br />- Select Top 5 objects <br />- Aggregated Functions</p>
<p><br /><img src="https://raw.githubusercontent.com/DevExpress-Examples/linq-to-xpo-e642/8.2.6+/media/c0d05f92-2d23-11e4-80b8-00155d624807.png"><br /><br /></p>
<p>For implementation details, see the <em>Form1.xx </em>file.<br /><br /></p>
<p><strong>Important notes:<br /></strong></p>
<p><strong>1.</strong> To evaluate expression on the server, use<a href="http://stackoverflow.com/questions/793571/why-would-you-use-expressionfunct-rather-than-funct"> Expression<Func<T>> instead of Func<T></a> . </p>
<p><strong>2.</strong> The maximum allowed number of total or group summaries is <strong>14</strong>.</p>
<p><strong>3.</strong> The <em>FirstOrDefault </em>method does not support the property initialization in the <em>Select </em>statement.</p>
<p><strong>4. </strong>Cross Join<em> </em>queries are not supported.<br /><br /></p>
<p><strong>See Also:<br /></strong><a href="http://msdn2.microsoft.com/en-us/library/bb308959.aspx">.NET Language-Integrated Query</a> <br /><a href="https://documentation.devexpress.com/#XPO/CustomDocument4060">eXpress Persistent Objects > Feature Center > Querying a Data Store > LINQ to XPO</a><br /><a href="https://documentation.devexpress.com/#XPO/CustomDocument9948">How to: Implement Custom Functions and Criteria in LINQ to XPO </a> <br /><a href="https://documentation.devexpress.com/#XPO/DevExpressXpoXPQueryExtensions_Query[T]topic">XPQueryExtensions.Query<T> </a> <br /><a href="https://documentation.devexpress.com/XPO/DevExpressXpoXPQueryExtensions_QueryInTransaction[T]topic.aspx">XPQueryExtensions.QueryInTransaction<T></a> <br /><a href="https://www.devexpress.com/Support/Center/p/E859">How to populate a List View with data from a LINQ query</a></p>

<br/>


