# GroupFile
Given a directory tree, with root folder name is “rootuploaded”, we need to combine files in this tree into some groups, using rules below:
● Files in different subfolders cannot be grouped.
● Files in a group may have same or different extension.
● Each group must have minimum 2 files, maximum 5 files.
● Grouping files based on 6 naming conventions (with top­down priority):
1. FileName.ext, FileName_anything.ext, FileName_anythingelse.ext, ...
2. FileName.ext, FileName­anything.ext, FileName­anythingelse.ext, ...
3. FileName_1.ext, FileName_2.ext, ..., FileName_N.ext (maybe not continuous)
4. FileName­1.ext, FileName­2.ext, ..., FileName­N.ext (maybe not continuous)
5. FileName 1.ext, FileName 2.ext, ..., FileName N.ext (maybe not continuous)
6. FileName1.ext, FileName2.ext, ..., FileNameN.ext (maybe not continuous)
