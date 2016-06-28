# GroupFile
Given a directory tree, with root folder name is “rootuploaded”, we need to combine files in this tree into some groups, using rules below:
<ul>
<li>Files in different subfolders cannot be grouped.</li>
<li>Files in a group may have same or different extension.</li>
<li>Each group must have minimum 2 files, maximum 5 files.</li>
<li>Grouping files based on 6 naming conventions (with top-down priority):
<ul>
<li>FileName.ext, FileName_anything.ext, FileName_anythingelse.ext, ...</li>
<li>FileName.ext, FileName­anything.ext, FileName­anythingelse.ext, ...</li>
<li>FileName_1.ext, FileName_2.ext, ..., FileName_N.ext (maybe not continuous)</li>
<li>FileName­1.ext, FileName­2.ext, ..., FileName­N.ext (maybe not continuous)</li>
<li>FileName 1.ext, FileName 2.ext, ..., FileName N.ext (maybe not continuous)</li>
<li>FileName1.ext, FileName2.ext, ..., FileNameN.ext (maybe not continuous)</li>
</ul></li>
</ul>

## Official Documentation
