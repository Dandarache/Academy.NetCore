param (
  [string]$firstname="Sven",
  [int]$age=50,
  [string]$toupper="no"
)

$apa=123 # skrivs inte ut

$text = "Hej " + $firstname + "! Om 30 år är du " + ($age+30) + " år gammal"

if ($toupper -eq "yes"){
    $text.ToUpper()
} else {
    $text
}