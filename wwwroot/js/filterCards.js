/**
 * @author Victor Chimenti
 * @file filterCards.js
 */




// check results for null
$(function assignVisibleItems() {
    // assign array of currently visible content items
    visibleItems = $('.card').not('.hideByText,' +
        ' .hideByHours,' +
        ' .hideByDriveThruOnly,' +
        ' .hideBySurcharge,' +
        ' .hideByAcceptDeposit,' +
        ' .hideBySelfServiceOnly,' +
        ' .hideByHandicapAccess');
    // check to see if array is empty
    if (visibleItems.length == 0) {
        // when array is empty show the results message
        $('.noResultsToShow').removeClass('hideResultsMessage');
    } else {
        // when array has content items suppress the results message
        $('.noResultsToShow').addClass('hideResultsMessage');
    }
});



$(function () {
    // After the DOM is ready, Wait until the window loads
    $(document).ready(function () {
        //$(document).ready(function () {

        // Once window loads set a timeout delay
        setTimeout(function () {



            //   ***   Keyword Search   ***   //
            $(function () {
                // scan the keyword each character the user inputs
                $('#keyword_search').on('keyup', function () {
                    // Assign Search Key
                    var key = $(this).val().toLowerCase();
                    // filter the cards for the input key
                    $(function () {
                        $('.card').filter(function () {
                            // when the search key is not present in the item then hide the item
                            $(this).toggleClass('hideByText', !($(this).text().toLowerCase().indexOf(key) > -1));
                        });
                    });
                });
                assignVisibleItems();
            });




            //   ***   24 Hours Filter   ***   //
            $(function () {
                // When the select box Hours changes - Execute change function
                $('#Hours').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Hours card items in card
                    if ($('#Hours:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.Hours').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideByHours');
                                } else {
                                    $(this).parents('.card').addClass('hideByHours');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByHours');
                        }
                    } else {
                        $('.card').removeClass('hideByHours');
                    }
                    assignVisibleItems();
                });
            });




            //   ***   Drive Thru Only   ***   //
            $(function () {
                // When the select box Drive Thru changes - Execute change function
                $('#DriveThruOnly').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Drive Thru card items
                    if ($('#DriveThruOnly:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.InstallationType').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideByDriveThruOnly');
                                } else {
                                    $(this).parents('.card').addClass('hideByDriveThruOnly');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByDriveThruOnly');
                        }
                    } else {
                        $('.card').removeClass('hideByDriveThruOnly');
                    }
                    assignVisibleItems();
                });
            });




            //   ***   Handicap Access   ***   //
            $(function () {
                // When the select box HandicapAccess changes - Execute change function
                $('#HandicapAccess').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the ccepts Deposits items
                    if ($('#HandicapAccess:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.HandicapAccess').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideByHandicapAccess');
                                } else {
                                    $(this).parents('.card').addClass('hideByHandicapAccess');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByHandicapAccess');
                        }
                    } else {
                        $('.card').removeClass('hideByHandicapAccess');
                    }
                    assignVisibleItems();
                });
            });




            //   ***   Surcharge   ***   //
            $(function () {
                // When the select box Surchargechanges - Execute change function
                $('#Surcharge').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Surcharge items
                    if ($('#Surcharge:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.Surcharge').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideBySurcharge');
                                } else {
                                    $(this).parents('.card').addClass('hideBySurcharge');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideBySurcharge');
                        }
                    } else {
                        $('.card').removeClass('hideBySurcharge');
                    }
                    assignVisibleItems();
                });
            });




            //   ***   Accepts Deposits   ***   //
            $(function () {
                // When the select box Deposits changes - Execute change function
                $('#AcceptDeposit').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the ccepts Deposits items
                    if ($('#AcceptDeposit:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.AcceptsDeposits').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideByAcceptDeposit');
                                } else {
                                    $(this).parents('.card').addClass('hideByAcceptDeposit');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByAcceptDeposit');
                        }
                    } else {
                        $('.card').removeClass('hideByAcceptDeposit');
                    }
                    assignVisibleItems();
                });
            });




            //   ***   NFC Drive Thru  ***   //
            $(function () {
                // When the select box Coin Star changes - Execute change function
                $('#NFCDriveThruOnly').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the Coin Star items
                    if ($('#NFCDriveThruOnly:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.DriveThruOnly').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideByDriveThruOnly');
                                } else {
                                    $(this).parents('.card').addClass('hideByDriveThruOnly');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideByDriveThruOnly');
                        }
                    } else {
                        $('.card').removeClass('hideByDriveThruOnly');
                    }
                    assignVisibleItems();
                });
            });




            //   ***   Self Service Only   ***   //
            $(function () {
                // When the select box Self Service Only changes - Execute change function
                $('#SelfServiceOnly').change(function () {
                    // Assign Search Key
                    var key = $(this).val();
                    // If Search Key is Not Null then Compare to the ccepts Deposits items
                    if ($('#SelfServiceOnly:checkbox').is(':checked', true)) {
                        if (key) {
                            $('.SelfServiceOnly').filter(function (i, e) {
                                var value = $(this).text();
                                // Check to see if the Key and Value are a Match
                                if (value.match(key)) {
                                    $(this).parents('.card').removeClass('hideBySelfServiceOnly');
                                } else {
                                    $(this).parents('.card').addClass('hideBySelfServiceOnly');
                                }
                            });
                            // Else the Search Key is Null so Reset all Content Items to Visible
                        } else {
                            $('.card').removeClass('hideBySelfServiceOnly');
                        }
                    } else {
                        $('.card').removeClass('hideBySelfServiceOnly');
                    }
                    assignVisibleItems();
                });
            });
        }, 5);
    });
});
