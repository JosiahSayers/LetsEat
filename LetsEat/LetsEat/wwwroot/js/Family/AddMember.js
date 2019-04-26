const searchButton = document.querySelector('input[type=submit]');
const searchResultsDiv = document.querySelector('div.search-results')
const apiUrl = `${window.location.origin}/api/searchForMemberToAdd?email=`;
console.log(apiUrl);