Open the us-500-helper-columns-unsorted.xlsx Excel sheet, you can add new columns if you like. The first column defines the original order. The second column defines a random order. Delete these two columns before you export.
The export will not sorrund cells with "" and will probably use ";" as separator. Use this command to restore the original format from powershell:
Import-Csv ".\us-500-semi.csv" -Delimiter ";" | Export-Csv ".\us-500.csv" -NoTypeInformation

The us-500-helper-columns-unsorted.xlsx sheet contains clean data: nothing to be trimmed, nothing is misspelled.