namespace svbnet.PiDraw.OpenVG
{
    public enum PathCommand
    {
        MoveToAbs = PathSegment.MoveTo | PathAbsRel.Absolute,
        MoveToRel = PathSegment.MoveTo | PathAbsRel.Relative,
        LineToAbs = PathSegment.LineTo | PathAbsRel.Absolute,
        LineToRel = PathSegment.LineTo | PathAbsRel.Relative,
        HlineToAbs = PathSegment.HlineTo | PathAbsRel.Absolute,
        HlineToRel = PathSegment.HlineTo | PathAbsRel.Relative,
        VlineToAbs = PathSegment.VlineTo | PathAbsRel.Absolute,
        VlineToRel = PathSegment.VlineTo | PathAbsRel.Relative,
        QuadToAbs = PathSegment.QuadTo | PathAbsRel.Absolute,
        QuadToRel = PathSegment.QuadTo | PathAbsRel.Relative,
        CubicToAbs = PathSegment.CubicTo | PathAbsRel.Absolute,
        CubicToRel = PathSegment.CubicTo | PathAbsRel.Relative,
        SquadToAbs = PathSegment.SquadTo | PathAbsRel.Absolute,
        SquadToRel = PathSegment.SquadTo | PathAbsRel.Relative,
        ScubicToAbs = PathSegment.ScubicTo | PathAbsRel.Absolute,
        ScubicToRel = PathSegment.ScubicTo | PathAbsRel.Relative,
        SccwarcToAbs = PathSegment.SccwarcTo | PathAbsRel.Absolute,
        SccwarcToRel = PathSegment.SccwarcTo | PathAbsRel.Relative,
        ScwarcToAbs = PathSegment.ScwarcTo | PathAbsRel.Absolute,
        ScwarcToRel = PathSegment.ScwarcTo | PathAbsRel.Relative,
        LccwarcToAbs = PathSegment.LccwarcTo | PathAbsRel.Absolute,
        LccwarcToRel = PathSegment.LccwarcTo | PathAbsRel.Relative,
        LcwarcToAbs = PathSegment.LcwarcTo | PathAbsRel.Absolute,
        LcwarcToRel = PathSegment.LcwarcTo | PathAbsRel.Relative,
    }
}