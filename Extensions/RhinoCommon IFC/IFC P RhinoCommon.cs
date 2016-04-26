// MIT License
// Copyright (c) 2016 Geometry Gym Pty Ltd

// Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
// and associated documentation files (the "Software"), to deal in the Software without restriction, 
// including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
// subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all copies or substantial 
// portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
// LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
// SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Reflection;
using System.IO;

using Rhino.Geometry;

namespace GeometryGym.Ifc
{
	public abstract partial class IfcPoint
	{
		internal virtual Point3d Coordinates { get { return Point3d.Unset; } }
	}
	public partial class IfcPolyline
	{
		internal IfcPolyline(DatabaseIfc db, Line l) : base(db) { Points = new List<IfcCartesianPoint>() { new IfcCartesianPoint(db, l.From), new IfcCartesianPoint(db, l.To) }; }
		internal IfcPolyline(DatabaseIfc db, Polyline pl) : base(db)
		{
			List<IfcCartesianPoint> points = new List<IfcCartesianPoint>(pl.Count);
			if (pl.IsClosed)
			{
				int ilast = pl.Count - 1;
				for (int icounter = 0; icounter < ilast; icounter++)
					points.Add(new IfcCartesianPoint(db, pl[icounter]));
				points.Add(points[0]);
			}
			else
			{
				for (int icounter = 0; icounter < pl.Count; icounter++)
					points.Add(new IfcCartesianPoint(db, pl[icounter]));
			}
			Points = points;
		}
	}
	public partial class IfcPlacement
	{
		protected IfcPlacement(DatabaseIfc db, Point2d position) : base(db) { Location = new IfcCartesianPoint(db, position); }

	}
}