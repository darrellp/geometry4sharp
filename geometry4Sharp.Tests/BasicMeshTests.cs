using g4;

namespace geometry4Sharp.Tests;

public class BasicMeshTests
{
    [Fact]
    public void TestCubeFromScratch()
    {
        // Create a unit cube with indices that look like this bad ascii art:
        //		7-----6
        //	  / |	 /|
        //	 /	|   / |
        //	4---+--5  |
        //	|	|  |  |
        //	|   3--+--2
        //	|  /   | /
        //	|/     |/
        //	0------1

        var vertices = new List<Vector3d> {
        new(0, 0, 0),
        new(1, 0, 0),
        new(1, 1, 0),
        new(0, 1, 0),
        new(0, 0, 1),
        new(1, 0, 1),
        new(1, 1, 1),
        new(0, 1, 1)
    };

        var triangles = new List<Index3i> {
        new (1, 0, 2),		// Base
		new (3, 2, 0),
        new (5, 0, 1),		// Front
		new (4, 0, 5),
        new (1, 2, 6),		// Right
		new (6, 5, 1),
        new (3, 0, 7),		// Left
		new (4, 7, 0),
        new (3, 6, 2),		// Back
		new (6, 3, 7),
        new (5, 7, 4),		// Top
		new (7, 5, 6)
    };

        List<Vector3d>? normals = null;

        DMesh3 mesh = DMesh3Builder.Build(vertices, triangles, normals);
        Assert.True(mesh.CheckValidity(false, FailMode.DebugAssert));
    }
}